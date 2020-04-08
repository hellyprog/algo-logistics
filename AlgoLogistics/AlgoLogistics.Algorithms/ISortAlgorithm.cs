namespace AlgoLogistics.Algorithms
{
	public interface ISortAlgorithm<TInput, TResult> : IAlgorithm
	{
		TResult Sort(TInput input);
	}
}
