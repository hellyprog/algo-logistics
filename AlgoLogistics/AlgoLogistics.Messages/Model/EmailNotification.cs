namespace AlgoLogistics.Messages.Model
{
	public class EmailNotification : Notification
	{
		public string ToEmail { get; set; }
		public string Subject { get; set; }
	}
}
