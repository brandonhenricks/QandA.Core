using QandA.Core.Answers;
using QandA.Core.Questions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QandA.Core.Builders
{
    public class QuestionBuilder : BuilderBase<IQuestion>, IQuestionBuilder
    {
        public override List<IQuestion> Items { get; }

        public QuestionBuilder(List<IQuestion> items)
        {
            Items = items ?? throw new ArgumentNullException(nameof(items));
        }

        public QuestionBuilder(List<IQuestion> questions, List<IAnswer> answers)
        {
            Items = questions ?? throw new ArgumentNullException(nameof(questions));

            foreach (var answer in answers)
            {
                var question = Items.FirstOrDefault(x => x.Id == answer.QuestionId);

                if (question is null) continue;

                AddAnswer(question, answer);
            }
        }

        public QuestionBuilder()
        {
            Items = new List<IQuestion>();
        }

        public IQuestionBuilder AddAnswer(IQuestion question, IAnswer answer)
        {
            if (question is null)
            {
                throw new ArgumentNullException(nameof(question));
            }

            if (answer is null)
            {
                throw new ArgumentNullException(nameof(answer));
            }

            AddAnswer(question.Id, answer);
            return this;
        }

        public IQuestionBuilder AddAnswer(Guid questionId, IAnswer answer)
        {
            if (answer is null)
            {
                throw new ArgumentNullException(nameof(answer));
            }

            var question = GetById(questionId);

            if (question is null)
            {
                throw new ArgumentException(nameof(questionId));
            }

            question.Answers.Add(answer);

            return this;
        }

        public IQuestionBuilder AddQuestion(IQuestion question)
        {
            if (question is null)
            {
                throw new ArgumentNullException(nameof(question));
            }

            base.Add(question);

            return this;
        }

        public List<IQuestion> Create()
        {
            return Items;
        }

        public IAnswer GetAnswerById(Guid answerId)
        {
            return Items.SelectMany(x => x.Answers).FirstOrDefault(x => x.Id == answerId);
        }

        public List<IAnswer> GetAnswersByQuestion(IQuestion question)
        {
            if (question is null)
            {
                throw new ArgumentNullException(nameof(question));
            }

            return GetAnswersByQuestionId(question.Id);
        }

        public List<IAnswer> GetAnswersByQuestionId(Guid questionId)
        {
            var question = GetById(questionId);

            if (question != null)
            {
                return question.Answers;
            }

            return null;
        }

        public IQuestionBuilder RemoveQuestion(IQuestion question)
        {
            if (question is null)
            {
                throw new ArgumentNullException(nameof(question));
            }

            base.Remove(question);

            return this;
        }

        public IQuestionBuilder RemoveQuestion(Guid questionId)
        {
            var question = GetById(questionId);

            if (question != null)
            {
                base.Remove(question);
            }

            return this;
        }

        private IQuestion GetById(Guid id)
        {
            return Items.FirstOrDefault(x => x.Id == id);
        }
    }
}