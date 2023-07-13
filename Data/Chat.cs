using chat_app.Models;
using Microsoft.EntityFrameworkCore;

namespace chat_app.Data
{
    public class Chat
    {
        private readonly ChatContext _db;

        public Chat(ChatContext db)
        {
            _db = db;
        }

        public UserMessages? Get(int id)
        {
            return _db.UserMessages.FirstOrDefault(pr => pr.Id == id);
        }

        public async Task<List<UserMessages>> LoadChatHistory(string username)
        {
            var userChatMessages = await _db.UserMessages
                .Where(m => m.Username == username)
                .ToListAsync();
            return userChatMessages;
        }

        public async Task SaveChatMessage(UserMessages chatMessage)
        {
            _db.UserMessages.Add(chatMessage);
            await _db.SaveChangesAsync();
        }
    }
}