using AlgoLogistics.Domain.Entities;
using AlgoLogistics.Domain.Services.BusinessLogic.Interfaces;
using AlgoLogistics.Domain.Services.Commands;
using AlgoLogistics.Domain.Services.Common.Models;
using AlgoLogistics.Messages.Model;
using AlgoLogistics.Messages.Producers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoLogistics.Application.CommandHandlers
{
	public class TransportCommandHandler :
		IRequestHandler<RegisterTransportDepartureCommand, ExecutionResult>,
		IRequestHandler<RegisterTransportArrivalCommand, ExecutionResult>
	{
		private readonly ITransportService transportService;
		private readonly INotificationProducer notificationProducer;

		public TransportCommandHandler(
			ITransportService transportService,
			INotificationProducer notificationProducer)
		{
			this.transportService = transportService;
			this.notificationProducer = notificationProducer;
		}

		public async Task<ExecutionResult> Handle(RegisterTransportDepartureCommand request, CancellationToken cancellationToken)
		{
			var executionResult = await transportService.RegisterTransportDeparture(request, cancellationToken);

			if (executionResult.Success)
			{
				var deliveryDetails = await transportService.GetTransportShipmentEmails(request.TransportNo);

				deliveryDetails?.Data.ForEach(d =>
				{
					var notification = CreateEmailNotification(d);
					notificationProducer.ProduceNotification(notification);
				});
			}

			return executionResult;
		}

		public async Task<ExecutionResult> Handle(RegisterTransportArrivalCommand request, CancellationToken cancellationToken)
		{
			var executionResult = await transportService.RegisterTransportArrival(request, cancellationToken);

			if (executionResult.Success)
			{
				var deliveryDetails = await transportService.GetTransportShipmentEmails(request.TransportNo);

				deliveryDetails?.Data.ForEach(d =>
				{
					var notification = CreateEmailNotification(d);
					notificationProducer.ProduceNotification(notification);
				});
			}

			return executionResult;
		}

		private EmailNotification CreateEmailNotification(DeliveryDetails deliveryDetails)
		{
			var notification = new EmailNotification
			{
				Message = $"Dear, {deliveryDetails.Receiver}. Your package from {deliveryDetails.FromCity} is shipping.",
				Subject = "Delivery",
				ToEmail = deliveryDetails.ReceiverEmail
			};

			return notification;
		}
	}
}
