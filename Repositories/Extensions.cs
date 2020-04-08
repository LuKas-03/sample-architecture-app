using Domain.Models;

namespace Repository
{
    internal static class Extensions
    {
        internal static User ToUserModel(this UserEntity userEntity)
        {
            return new User(userEntity.UserId)
            {
                Name = userEntity.Name
            };
        }

        internal static Note ToNoteModel(this NoteEntity noteEntity)
        {
            return new Note(noteEntity.NoteId, noteEntity.CreateDateTime)
            {
                Title = noteEntity.Title,
                Text = noteEntity.Text,
                AuthorUserId = noteEntity.AuthorUserId
            };
        }
    }
}
