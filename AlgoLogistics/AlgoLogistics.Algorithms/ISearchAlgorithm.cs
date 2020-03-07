using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoLogistics.Algorithms
{
	public interface ISearchAlgorithm<TInput, TResult> : IAlgorithm
	{
		TResult Search(TInput input);
	}
}
