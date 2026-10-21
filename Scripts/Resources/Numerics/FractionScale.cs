using System;

namespace DMBTools
{
    public class FractionScale
    {
        public static readonly FractionScale zero = new FractionScale(0, 0);
        int _numerator;
        readonly int _denominator;
        public FractionScale(int num = 0, int den = 0)
        {
            if(den == 0 && num != 0) throw new ArgumentException("A fraction cannot have a zero denominator and a non-zero numerator.");
            _numerator = num;
            _denominator = den;
        }
        public FractionScale(int integer) : this(integer, 1) { }
        public FractionScale(FractionScale f) : this(f._numerator, f._denominator) { }
        public int Numerator { get; set; }
        public int Denominator { get; }
        public void Decrement(int amount = 1)
        {
            _numerator -= amount;
        }
        public void Increment(int amount = 1)
        {
            _numerator += amount;
        }
        public int ToInt()
        {
            return _numerator / _denominator;
        }
        public int ToIntFloor()
        {
            return (int)Math.Floor(this.ToFloat());
        }
        public int ToIntCeiling()
        {
            return (int)Math.Ceiling(this.ToFloat());
        }
        public double ToDouble()
        {
            return (double)_numerator / (double)_denominator;
        }
        public float ToFloat()
        {
            return (float)_numerator / (float)_denominator;
        }
        override public string ToString()
        {
            return $"{_numerator} / {_denominator}";
        }
        public bool IsFull()
        {
            return _numerator >= _denominator;
        }
        FractionScale Add(FractionScale f)
        {
            if (this.Denominator == f.Denominator)
            {
                return new FractionScale(this.Numerator + f.Numerator, this.Denominator);
            }
            else
            {
                int new_denominator = this.Denominator * f.Denominator;

                FractionScale fraction_a = new FractionScale
                (
                    this.Numerator * f.Denominator,
                    new_denominator
                );
                FractionScale fraction_b = new FractionScale
                (
                    f.Numerator * this.Denominator,
                    new_denominator
                );
                return fraction_a.Add(fraction_b);
            }
        }
    }
}