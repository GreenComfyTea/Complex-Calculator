using System;
using System.Windows;
using System.Diagnostics;
using System.Numerics;

namespace ComplexCalculator
{
	public partial class MainWindow : Window
	{
		private Complex first;
		private Complex second;
		private Complex result;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void ReadFirstOperand()
		{
			bool realSuccess = double.TryParse(firstReal.Text.Replace(',', '.'), out double real);
			bool imaginarySuccess = double.TryParse(firstImaginary.Text.Replace(',', '.'), out double imaginary);

			if(!realSuccess || !imaginarySuccess)
			{
				throw new FormatException();
			}

			first = new Complex(real, imaginary); 
		}

		private void ReadSecondOperand()
		{
			bool realSuccess = double.TryParse(secondReal.Text.Replace(',', '.'), out double real);
			bool imaginarySuccess = double.TryParse(secondImaginary.Text.Replace(',', '.'), out double imaginary);

			if (!realSuccess || !imaginarySuccess)
			{
				throw new FormatException();
			}

			second = new Complex(real, imaginary);
		}

		private void ClearAll()
		{
			ClearAllButSecond();
			ClearSecond();
		}

		private void ClearAllButSecond()
		{
			resultReal.Text = "";
			resultImaginary.Text = "";

			firstAbs.Text = "";
			resultAbs.Text = "";

			firstPhi.Text = "";
			resultPhi.Text = "";

			firstAlgebraic.Text = "";
			resultAlgebraic.Text = "";

			firstPolar.Text = "";
			resultPolar.Text = "";

			firstExponential.Text = "";
			resultExponential.Text = "";
		}

		private void ClearSecond()
		{
			secondAbs.Text = "";
			secondPhi.Text = "";
			secondAlgebraic.Text = "";
			secondPolar.Text = "";
			secondExponential.Text = "";
		}

		private void ShowResult()
		{
			resultReal.Text = result.Real.ToString();
			resultImaginary.Text = result.Imaginary.ToString();
		}

		private void ProcessFirst()
		{
			firstAbs.Text = Complex.Abs(first).ToString();
			firstPhi.Text = Complex.Phi(first).ToString();
			firstAlgebraic.Text = first.ToString();
			firstPolar.Text = Complex.PolarForm(first);
			firstExponential.Text = Complex.ExponentialForm(first);
		}

		private void ProcessSecond()
		{
			secondAbs.Text = Complex.Abs(second).ToString();
			secondPhi.Text = Complex.Phi(second).ToString();
			secondAlgebraic.Text = second.ToString();
			secondPolar.Text = Complex.PolarForm(second);
			secondExponential.Text = Complex.ExponentialForm(second);
		}

		private void ProcessResult()
		{
			resultAbs.Text = Complex.Abs(result).ToString();
			resultPhi.Text = Complex.Phi(result).ToString();
			resultAlgebraic.Text = result.ToString();
			resultPolar.Text = Complex.PolarForm(result);
			resultExponential.Text = Complex.ExponentialForm(result);
		}

		private void Conjugate(object sender, RoutedEventArgs e)
		{
			try
			{
				ReadFirstOperand();
			}
			catch (FormatException)
			{
				resultReal.Text = "Error!";
				return;
			}

			result = Complex.Conjugate(first);

			ClearAllButSecond();
			ShowResult();
			ProcessFirst();
			ProcessResult();
		}

		private void Recipropal(object sender, RoutedEventArgs e)
		{
			try
			{
				ReadFirstOperand();
			}
			catch (FormatException)
			{
				resultReal.Text = "Error!";
				return;
			}

			result = Complex.Reciprocal(first);

			ClearAllButSecond();
			ShowResult();
			ProcessFirst();
			ProcessResult();
		}

		private void Add(object sender, RoutedEventArgs e)
		{
			try
			{
				ReadFirstOperand();
				ReadSecondOperand();
			}
			catch (FormatException)
			{
				resultReal.Text = "Error!";
				return;
			}

			result = first + second;

			ClearAll();
			ShowResult();
			ProcessFirst();
			ProcessSecond();
			ProcessResult();
		}

		private void Substract(object sender, RoutedEventArgs e)
		{
			try
			{
				ReadFirstOperand();
				ReadSecondOperand();
			}
			catch (FormatException)
			{
				resultReal.Text = "Error!";
				return;
			}

			result = first - second;

			ClearAll();
			ShowResult();
			ProcessFirst();
			ProcessSecond();
			ProcessResult();
		}

		private void Multiply(object sender, RoutedEventArgs e)
		{
			try
			{
				ReadFirstOperand();
				ReadSecondOperand();
			}
			catch (FormatException)
			{
				resultReal.Text = "Error!";
				return;
			}

			result = first * second;

			ClearAll();
			ShowResult();
			ProcessFirst();
			ProcessSecond();
			ProcessResult();
		}

		private void Divide(object sender, RoutedEventArgs e)
		{
			try
			{
				ReadFirstOperand();
				ReadSecondOperand();
			}
			catch (FormatException)
			{
				resultReal.Text = "Error!";
				return;
			}

			result = first / second;

			ClearAll();
			ShowResult();
			ProcessFirst();
			ProcessSecond();
			ProcessResult();
		}

		private void Pow(object sender, RoutedEventArgs e)
		{
			try
			{
				ReadFirstOperand();
				ReadSecondOperand();
			}
			catch (FormatException)
			{
				resultReal.Text = "Error!";
				return;
			}

			result = Complex.Pow(first, second);

			ClearAll();
			ShowResult();
			ProcessFirst();
			ProcessSecond();
			ProcessResult();
		}

		private void Nop(object sender, RoutedEventArgs e)
		{
			try
			{
				ReadFirstOperand();
			}
			catch (FormatException)
			{
				resultReal.Text = "Error!";
				return;
			}

			ClearAll();
			ProcessFirst();
		}
	}
}
