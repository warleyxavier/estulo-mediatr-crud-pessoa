using MediatR;

namespace estulo_mediatr_crud_pessoa.Notifications
{
    public class PersonDeletedNotification : INotification
    {
        public string Id { get; set; }

        public PersonDeletedNotification(string id)
        {
            Id = id;
        }
    }
}
