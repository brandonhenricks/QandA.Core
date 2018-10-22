using System;

namespace QandA.Core.Answers
{
    public class Answer : IAnswer
    {
        public Guid QuestionId { get; set; }
        public Guid Id { get; set; }
        public string Value { get; set; }
        public bool IsCorrect { get; set; }

        public Answer()
        {
            Id = Guid.NewGuid();
        }
        public Answer(Guid questionId, string value) : base()
        {
            QuestionId = questionId;
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public Answer(Guid questionId, string value, bool isCorrect) : base()
        {
            QuestionId = questionId;
            Value = value ?? throw new ArgumentNullException(nameof(value));
            IsCorrect = isCorrect;
        }
    }
}
