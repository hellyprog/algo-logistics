using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace AlgoLogistics.Domain.Algorithms
{
	public class MeasurableAlgorithm<TInput, TResult> : IAlgorithm<TInput, TResult>
	{
		private readonly IAlgorithm<TInput, TResult> _algorithm;

		public MeasurableAlgorithm(IAlgorithm<TInput, TResult> algorithm)
		{
			_algorithm = algorithm;
		}

		public TResult Execute(TInput input)
		{
			var sw = Stopwatch.StartNew();
			var result = _algorithm.Execute(input);
			sw.Stop();

			WriteTimeToFile(sw.ElapsedMilliseconds);

			return result;
		}

		private void WriteTimeToFile(long ms)
		{
			using (var streamWriter = new StreamWriter("result.txt", false))
			{
				streamWriter.Write(ms);
			}
		}
	}
}
