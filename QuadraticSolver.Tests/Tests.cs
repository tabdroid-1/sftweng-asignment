using Xunit;
using QuadraticSolver;
using System;

namespace QuadraticSolver.Tests
{
    public class QuadraticEquationSolverTests
    {
        [Theory]
        [InlineData(1, 2, 5)]
        [InlineData(1, 0, 1)]
        public void Solve_NoRealRoots_ReturnsZeroRoots(double a, double b, double c)
        {
            var result = QuadraticEquationSolver.Solve(a, b, c);
            Assert.Equal(0, result.numberOfRoots);
            Assert.Null(result.root1);
            Assert.Null(result.root2);
        }

        [Theory]
        [InlineData(1, 2, 1, -1)]
        [InlineData(4, 4, 1, -0.5)]
        public void Solve_OneRealRoot_ReturnsOneRoot(double a, double b, double c, double expectedRoot)
        {
            var result = QuadraticEquationSolver.Solve(a, b, c);
            Assert.Equal(1, result.numberOfRoots);
            Assert.Equal(expectedRoot, result.root1.Value, 5);
            Assert.Equal(result.root1, result.root2);
        }

        [Theory]
        [InlineData(1, -3, 2, 2, 1)]
        [InlineData(1, 0, -1, 1, -1)]
        public void Solve_TwoRealRoots_ReturnsTwoRoots(double a, double b, double c, double expected1, double expected2)
        {
            var result = QuadraticEquationSolver.Solve(a, b, c);
            Assert.Equal(2, result.numberOfRoots);
            Assert.Contains(result.root1.Value, new[] { expected1, expected2 });
            Assert.Contains(result.root2.Value, new[] { expected1, expected2 });
        }

        [Fact]
        public void Solve_ZeroA_ThrowsException()
        {
            var ex = Assert.Throws<ArgumentException>(() => QuadraticEquationSolver.Solve(0, 1, 1));
            Assert.Equal("Coefficient 'a' cannot be zero for a quadratic equation.", ex.Message);
        }
    }
}
