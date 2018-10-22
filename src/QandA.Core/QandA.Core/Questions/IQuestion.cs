using QandA.Core.Answers;
using QandA.Core.Enums;
using System;
using System.Collections.Generic;

namespace QandA.Core.Questions
{
    public interface IQuestion
    {
        Guid Id { get; }
        string DisplayText { get; set; }
        int MaxAttempts { get; set; }
        int AttemptCount { get; set; }
        List<IAnswer> Answers { get; }
        QuestionStatus Status { get; }
        QuestionType QuestionType { get; set; }
        bool SubmitAnswer(Guid answerId);
        bool SubmitAnswer(IAnswer answer);
    }
}
