using QandA.Core.Answers;
using QandA.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QandA.Core.Questions
{
    public class Question : IQuestion
    {
        public Guid Id { get; protected set; }
        public Guid SessionId { get; protected set; }
        public int MaxAttempts { get; set; }
        public int AttemptCount { get; set; }
        public string DisplayText { get; set; }
        public List<IAnswer> Answers { get; }
        public QuestionStatus Status { get; protected set; }
        public QuestionType QuestionType { get; set; }

        public Question()
        {
            Id = Guid.NewGuid();
            AttemptCount = 0;
            Status = QuestionStatus.None;
            Answers = new List<IAnswer>();
            AttemptCount = 0;
            QuestionType = QuestionType.Default;
        }

        public Question(List<IAnswer> answers) : base()
        {
            Answers = answers;
        }

        public Question(string displayText, List<IAnswer> answers) : base()
        {
            if (string.IsNullOrEmpty(displayText))
            {
                throw new ArgumentNullException(nameof(displayText));
            }

            DisplayText = displayText;
            Answers = answers;
        }

        public void SetSessionId(Guid sessionId)
        {
            SessionId = sessionId;
        }

        public bool SubmitAnswer(IAnswer answer)
        {
            if (answer is null)
            {
                throw new ArgumentNullException(nameof(answer));
            }

            return SubmitAnswer(answer.Id);
        }

        public bool SubmitAnswer(Guid answerId)
        {
            AttemptCount++;

            if (AttemptCount >= MaxAttempts)
            {
                Status = QuestionStatus.Locked;
                return false;
            }

            var result = Answers.Any(x => x.Id == answerId && x.IsCorrect);

            if (result)
            {
                Status = QuestionStatus.Correct;
            }

            return result;
        }
    }
}