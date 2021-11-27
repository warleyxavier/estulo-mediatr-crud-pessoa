using estulo_mediatr_crud_pessoa.Notifications;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace estulo_mediatr_crud_pessoa.NotificationHandlers
{
    public class PersonNotificationHandler :
        INotificationHandler<PersonCreatedNotification>,
        INotificationHandler<PersonUpdatedNotification>,
        INotificationHandler<PersonDeletedNotification>
    {
        public Task Handle(PersonCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Person { notification.Id} added succefully");

            return Task.CompletedTask;
        }

        public Task Handle(PersonUpdatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Person { notification.Id} updated succefully");

            return Task.CompletedTask;
        }

        public Task Handle(PersonDeletedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Person { notification.Id} deleted succefully");

            return Task.CompletedTask;
        }
    }
}
