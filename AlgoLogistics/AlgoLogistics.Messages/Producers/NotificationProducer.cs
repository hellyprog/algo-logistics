using AlgoLogistics.Messages.Model;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace AlgoLogistics.Messages.Producers
{
	public class NotificationProducer : INotificationProducer
	{
		private readonly string _hostname;
		private readonly string _queueName;
		private readonly string _username;
		private readonly string _password;

		public NotificationProducer(IOptions<RabbitMqConfiguration> rabbitMqOptions)
		{
			_hostname = rabbitMqOptions.Value.Hostname;
			_queueName = rabbitMqOptions.Value.QueueName;
			_username = rabbitMqOptions.Value.UserName;
			_password = rabbitMqOptions.Value.Password;
		}

		public void ProduceNotification<T>(T notification) where T : Notification
		{
			var factory = new ConnectionFactory() { HostName = _hostname, UserName = _username, Password = _password };

			using var connection = factory.CreateConnection();
			using var channel = connection.CreateModel();
			channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

			var serializedNotification = JsonConvert.SerializeObject(notification);
			var body = Encoding.UTF8.GetBytes(serializedNotification);

			channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
		}
	}
}
