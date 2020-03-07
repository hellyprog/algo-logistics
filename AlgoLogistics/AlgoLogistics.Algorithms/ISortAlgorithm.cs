using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Algorithms
{
	public interface ISortAlgorithm<TInput, TResult> : IAlgorithm
	{
		TResult Sort(TInput input);
	}
}
