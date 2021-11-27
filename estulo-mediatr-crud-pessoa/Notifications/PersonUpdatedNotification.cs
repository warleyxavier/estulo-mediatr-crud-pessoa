using MediatR;

namespace estulo_mediatr_crud_pessoa.Notifications
{
    public class PersonUpdatedNotification : INotification
    {
        public string Id { get; set; }

        public PersonUpdatedNotification(string id)
        {
            Id = id;
        }
    }
}
