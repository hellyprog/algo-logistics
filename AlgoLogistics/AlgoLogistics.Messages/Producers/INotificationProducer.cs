using AlgoLogistics.Messages.Model;

namespace AlgoLogistics.Messages.Producers
{
	public interface INotificationProducer
	{
		void ProduceNotification<T>(T notification) where T : Notification;
	}
}
