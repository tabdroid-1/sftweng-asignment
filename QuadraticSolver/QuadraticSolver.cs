using System;

namespace QuadraticSolver
{
    public class QuadraticEquationSolver
    {
        public static (int numberOfRoots, double? root1, double? root2) Solve(double a, double b, double c)
        {
            if (a == 0)
                throw new ArgumentException("Coefficient 'a' cannot be zero for a quadratic equation.");

            double discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
                return (0, null, null);

            if (discriminant == 0)
            {
                double root = -b / (2 * a);
                return (1, root, root);
            }

            double sqrtDiscriminant = Math.Sqrt(discriminant);
            double root1 = (-b + sqrtDiscriminant) / (2 * a);
            double root2 = (-b - sqrtDiscriminant) / (2 * a);
            return (2, root1, root2);
        }
    }
}
