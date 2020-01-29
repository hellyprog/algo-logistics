using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Algorithms
{
	public interface IAlgorithm<TInput, TResult>
	{
		TResult Execute(TInput input);
	}
}
