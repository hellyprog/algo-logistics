namespace AlgoLogistics.Messages.Producers
{
	public interface INotificationProducer
	{
		void ProduceNotification(string notification);
	}
}
