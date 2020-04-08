using Core.Ports;
using Domain.Interfaces;
using Domain.Models;
using Ninject;
using System;
using System.Linq;

namespace Core.Services
{
    public class NoteService : INoteService
    {
        private readonly IUserRepository userRepository;
        private readonly INoteRepository noteRepository;

        [Inject]
        public NoteService(IUserRepository userRepository, INoteRepository noteRepository)
        {
            this.userRepository = userRepository;
            this.noteRepository = noteRepository;
        }

        public void AddNewNote(string title, string text, string userName)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(text) || string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException();
            }

            var user = userRepository.GetByName(userName);
            if (user == null)
            {
                throw new ArgumentException($"Пользователь с name = {userName} не найден");
            }

            noteRepository.Add(title, text, user.UserId);
        }

        public Note GetNoteById(int noteId)
        {
            return noteRepository.GetById(noteId);
        }

        public Note[] GetUserNotes(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }

            var user = userRepository.GetByName(userName);

            if (user == null)
            {
                throw new ArgumentException($"Пользователь с name = {userName} не найден");
            }

            return noteRepository.GetByUserId(user.UserId).ToArray();
        }
    }
}
