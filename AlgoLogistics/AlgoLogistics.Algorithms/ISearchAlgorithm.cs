namespace AlgoLogistics.Algorithms
{
	public interface ISearchAlgorithm<TInput, TResult> : IAlgorithm
	{
		TResult Search(TInput input);
	}
}
