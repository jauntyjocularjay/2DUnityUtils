# FractionScale
A handy little simplified fraction script. No reductions, no complicated features. Just used to keep track of integers. The companion `UFractionsScale` handles larger integers but incorporates a boolean to keep track of positivity or negativity.

## Constructors

### FractionScale(int num, int den)
Initializes the numerator and denominator with the provided values.

### FractionScale(int integer)
Initializes both numerator and denominator with the same integer value.

### FractionScale(FractionScale f)
Copy constructor that initializes the numerator and denominator with the values from another FractionScale instance.

## Getters:

### Get()
Returns the numerator.

### GetNumerator()
Returns the numerator.

### GetDenominator()
Returns the denominator.

## Setters:

### SetNumerator(int n)
Sets the numerator to the provided value.

## Increment/Decrement

### Decrement()
Decreases the numerator by 1.

### Decrement(int amount)
Decreases the numerator by the specified amount.

### Increment()
Increases the numerator by 1.

### Increment(int amount)
Increases the numerator by the specified amount.

## Conversion:

### ToInt()
Returns the integer division of numerator by denominator.

### ToDouble()
Returns the division of numerator by denominator as a double.

### ToFloat()
Returns the division of numerator by denominator as a float.

## Utility:

### ToString()
Returns a string representation of the fraction in the format "numerator / denominator".

### Full()
Returns true if the numerator is a whole or mixed number.
