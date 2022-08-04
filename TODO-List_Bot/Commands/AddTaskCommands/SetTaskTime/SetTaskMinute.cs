using Microsoft.Extensions.Caching.Memory;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TODO_List_Bot.Interfaces;
using TODO_List_Bot.Services;

namespace TODO_List_Bot.Commands.AddTaskCommands;

public class SetTaskMinute : IAddTaskCommand
{
    public void Add(ITelegramBotClient bot, Message message)
    {
        HandleUpdateService._cache.Remove("AddAction" + message.From.Id);
        
        FinishAddTask.AddTask(bot, message);
        
        bot.SendTextMessageAsync(chatId: message.Chat.Id,
            text: "Введите минуты");

        HandleUpdateService._cache.Set("Hour" + message.From.Id, Int32.Parse(message.Text));
    }
  
}