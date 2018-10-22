using System;

namespace QandA.Core.Answers
{
    public interface IAnswer
    {
        Guid QuestionId { get; set; }
        Guid Id { get; set; }
        string Value { get; set; }
        bool IsCorrect { get; set; }
    }
}