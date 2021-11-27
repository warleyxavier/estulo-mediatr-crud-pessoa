using MediatR;

namespace estulo_mediatr_crud_pessoa.Notifications
{
    public class PersonCreatedNotification : INotification
    {
        public string Id { get; set; }

        public PersonCreatedNotification(string id)
        {
            Id = id;
        }
    }
}
