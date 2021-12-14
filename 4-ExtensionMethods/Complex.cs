namespace ExtensionMethods
{
    using System;

    /// <inheritdoc cref="IComplex"/>
    public class Complex : IComplex
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Complex"/> class.
        /// </summary>
        /// <param name="re">the real part.</param>
        /// <param name="im">the imaginary part.</param>
        public Complex(double re, double im)
        {
            Real = re;
            Imaginary = im;
        }

        /// <inheritdoc cref="IComplex.Real"/>
        public double Real
        {
            get;
        }

        /// <inheritdoc cref="IComplex.Imaginary"/>
        public double Imaginary
        {
            get;
        }

        /// <inheritdoc cref="IComplex.Modulus"/>
        public double Modulus => System.Math.Sqrt(Real * Real + Imaginary * Imaginary);

        /// <inheritdoc cref="IComplex.Phase"/>
        public double Phase => System.Math.Atan2(Imaginary, Real);

        /// <inheritdoc cref="IComplex.ToString"/>
        public override string ToString()
        {
            string n = "";
            if (Real > 0)
            {
                n = "+" + Real.ToString();
            }
            else if (Real < 0)
            {
                n = Real.ToString();
            }
            else
            {
                //Real=0
            }


            if (Imaginary * Imaginary == 1)
            {
                n = n + (Imaginary == 1 ? "+i" : "-i");
            }
            else if (Imaginary > 0)
            {
                n = n + "+" + Imaginary.ToString();
            }
            else if (Imaginary < 0)
            {
                n = n + Imaginary.ToString();
            }
            else
            {
                //Immaginary=0
            }

            if (Real == 0 && Imaginary == 0) return "0";

            return n;
        }

        /// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(IComplex other)
        {
            return (Real.Equals(other.Real)) && (Imaginary.Equals(other.Imaginary));
        }

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj)
        {
            if (obj.GetType() == GetType())
            {
                return Equals((Complex)obj);
            }
            throw new InvalidCastException("Cannot compare a not Complex to a Complex");
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Real, Imaginary);
        }
    }
}
