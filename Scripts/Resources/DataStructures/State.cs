using System.IO;

namespace DMBTools
{
    /// <summary>
    /// Represents a named boolean state used in game state management systems.
    /// Designed as a value type for memory efficiency and immutability.
    /// 
    /// Key design decisions:
    /// - Keys are automatically normalized to lowercase for case-insensitive comparison
    /// - Value equality compares boolean values only, ignoring keys
    /// - Strict equality compares both key and boolean value for complete state verification
    /// - Value type (struct) for better performance in collections
    /// - Serializable for Unity inspector and persistence support
    /// 
    /// Common usage patterns:
    /// - Game flags: State("hasKey", true), State("doorLocked", false)
    /// - Character states: State("grounded", true), State("attacking", false)
    /// - Level conditions: State("bossDefeated", true), State("secretFound", false)
    /// 
    /// Equality semantics:
    /// - ValueEquals(): Compares boolean values only - "Do these states have the same value?"
    /// - StrictlyEquals(): Compares complete state (key + value) - "Are these completely identical?"
    /// 
    /// Performance considerations:
    /// - Struct copying overhead when passed by value
    /// - String comparison for equality checks
    /// - Case conversion on every construction
    /// </summary>
    [System.Serializable]
    public struct State
    {
        /// <summary>
        /// The unique identifier for this state.
        /// Automatically converted to lowercase for consistent comparison.
        /// Should follow naming conventions like "snake_case".
        /// </summary>
        public readonly string key;
        
        /// <summary>
        /// The boolean value representing whether this state is active/true or inactive/false.
        /// </summary>
        /// <remarks>
        /// Note: This field is the primary comparison point for ValueEquals() - states with
        /// the same boolean value are considered "value equal" regardless of their keys.
        /// StrictlyEquals() considers both key and value for complete state comparison.
        /// </remarks>
        public bool flag;

        /// <summary>
        /// Creates a new State with the specified key and boolean value.
        /// The key is automatically converted to lowercase for consistent comparison.
        /// </summary>
        /// <param name="key">
        /// The unique identifier for this state. 
        /// Will be converted to lowercase automatically.
        /// Should not be null or empty.
        /// </param>
        /// <param name="flag">The boolean value for this state</param>
        /// <remarks>
        /// Performance note: ToLower() creates a new string allocation on each call.
        /// For performance-critical scenarios, consider pre-normalizing keys.
        /// 
        /// Design consideration: Automatic case conversion may hide bugs where
        /// different parts of code expect different casing conventions.
        /// </remarks>
        public State(string key, bool flag)
        {

            this.key = key.ToLower(); // Normalize for case-insensitive comparison
            this.flag = flag;
        }
        
        /// <summary>
        /// Creates a new State with the specified key and a default value of false.
        /// Convenient constructor for initializing states that start as inactive.
        /// </summary>
        /// <param name="key">
        /// The unique identifier for this state.
        /// Will be converted to lowercase automatically.
        /// </param>
        /// <example>
        /// <code>
        /// State powerUpCollected = new State("powerUpCollected"); // defaults to false
        /// State doorUnlocked = new State("doorUnlocked", true);   // explicit true
        /// </code>
        /// </example>
        public State(string key): this(key, false) { }

        /// <summary>
        /// Determines value equality based on the boolean flag, ignoring the key.
        /// This compares only the flag values to determine if states have the same boolean value.
        /// </summary>
        /// <param name="target">The State to compare with this instance</param>
        /// <returns>true if both States have the same boolean value; otherwise, false</returns>
        /// <remarks>
        /// This represents boolean value equality - two States are "value equal" if they
        /// have the same flag value, regardless of their keys.
        /// 
        /// Use this when you want to check if different states have the same boolean value.
        /// Use StrictlyEquals() when you need to verify that both key and value match.
        /// 
        /// Example: new State("jumping", false).ValueEquals(new State("airborne", false)) == true
        /// because both states have the same boolean value (false), even though they have different keys.
        /// </remarks>
        readonly public bool ValueEquals(State target) => target.flag == flag;

        /// <summary>
        /// Determines strict equality based on both the key and the boolean value.
        /// Use this when you need to verify that two States are completely identical in all fields.
        /// </summary>
        /// <param name="target">The State to compare with this instance</param>
        /// <returns>true if both key and flag match exactly; otherwise, false</returns>
        /// <remarks>
        /// This method provides strict field-by-field equality comparison.
        /// Use this for:
        /// - Verifying that state changes have NOT occurred
        /// - Implementing exact state comparison logic  
        /// - Validating expected state configurations including values
        /// - Unit testing where precise state matching is required
        /// 
        /// Contrast with ValueEquals() which only compares the boolean values (ignoring keys).
        /// 
        /// Example: new State("jump", true).StrictlyEquals(new State("leap", true)) == false
        /// because while they have the same boolean value, their keys differ.
        /// </remarks>
        readonly public bool StrictlyEquals(State target) =>
            target.key == key &&
            target.flag == flag;

        /// <summary>
        /// Determines equality based on boolean values only (ignores keys).
        /// This operator provides value-based comparison where different states with same boolean values are considered equal.
        /// </summary>
        /// <param name="left">The first State to compare</param>
        /// <param name="right">The second State to compare</param>
        /// <returns>true if both states have the same boolean value; otherwise, false</returns>
        /// <remarks>
        /// Implements value-equality semantics via ValueEquals() method.
        /// Example: new State("jump", true) == new State("leap", true) returns true
        /// because both have the same boolean value despite different keys.
        /// </remarks>
        public static bool operator ==(State left, State right)
        {
            return left.ValueEquals(right);
        }

        /// <summary>
        /// Determines inequality based on boolean values only (ignores keys).
        /// Returns the negation of the == operator result.
        /// </summary>
        /// <param name="left">The first State to compare</param>
        /// <param name="right">The second State to compare</param>
        /// <returns>true if states have different boolean values; otherwise, false</returns>
        public static bool operator !=(State left, State right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Implicitly converts a State to its boolean value for convenient conditional usage.
        /// Allows natural syntax like: if (state) { ... } instead of if (state.flag) { ... }
        /// </summary>
        /// <param name="state">The State to convert to boolean</param>
        /// <returns>The boolean value (flag) of the state</returns>
        /// <remarks>
        /// This conversion enables clean conditional logic and boolean operations on State instances.
        /// Examples:
        /// - if (jumpingState) { ... }
        /// - bool canMove = !isStunnedState;
        /// - results.Add(myState && otherCondition);
        /// </remarks>
        public static implicit operator bool(State state)
        {
            return state.flag;
        }
            
        /*
         * ===== State DESIGN ANALYSIS =====
         * 
         * STRENGTHS:
         * + Value type reduces heap allocations compared to class
         * + Immutable-like design (readonly key, constructor sets final values)
         * + Case-insensitive key comparison prevents common bugs
         * + Dual equality semantics: ValueEquals() for boolean comparison, StrictlyEquals() for complete comparison
         * + Serializable for Unity integration
         * + Clear separation between state identity (key) and state value (flag)
         * + Equality operators (==, !=) with value-based comparison semantics
         * + Implicit bool conversion for convenient conditional usage
         * 
         * POTENTIAL ISSUES:
         * - System.IO import seems unnecessary for this general-purpose struct
         * - ToLower() allocation on every construction
         * - No validation for null/empty keys
         * 
         * IMPROVEMENT OPPORTUNITIES:
         * 1. Add key validation (null/empty checks) in constructor
         * 2. Consider string interning for common keys to reduce memory pressure
         * 3. Remove unnecessary System.IO dependency 
         * 4. Consider static factory methods for common states
         * 
         * USAGE RECOMMENDATIONS:
         * - Use ValueEquals() or == for boolean value comparison (most common)
         * - Use StrictlyEquals() for verifying exact state including keys
         * - Use implicit bool conversion for conditionals: if(state) { ... }
         * - Prefer constructor with explicit bool value for clarity
         * - Be consistent about key naming conventions across codebase
         * - Consider caching common State instances to reduce allocations
         */
    }
}