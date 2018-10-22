using QandA.Core.Answers;
using QandA.Core.Questions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QandA.Core.Builders
{
    /// <summary>
    /// Helper Class to Create <see cref="List{IQuestion}"/>
    /// </summary>
    public class QuestionBuilder : BuilderBase<IQuestion>, IQuestionBuilder
    {
        #region Public Properties
        public override List<IQuestion> Items { get; }
        #endregion
        
        #region Public Constructors
        /// <summary>
        /// Public Constructor that sets <see cref="List{T}"/> of <see cref="IQuestion"/>
        /// </summary>
        /// <param name="items"></param>
        public QuestionBuilder(List<IQuestion> items)
        {
            Items = items ?? throw new ArgumentNullException(nameof(items));
        }

        /// <summary>
        /// Public Constructor that sets <see cref="List{T}"/> of <see cref="IQuestion"/> with <see cref="IAnswer"/>
        /// </summary>
        /// <param name="questions"></param>
        /// <param name="answers"></param>
        /// <exception cref="ArgumentNullException"></exception>
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

        /// <summary>
        /// Default Constructor
        /// </summary>
        public QuestionBuilder()
        {
            Items = new List<IQuestion>();
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Add an <see cref="IAnswer"/> to an existing <see cref="IQuestion"/>
        /// </summary>
        /// <param name="question"></param>
        /// <param name="answer"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
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

        /// <summary>
        /// Add an <see cref="IAnswer"/> to an existing <see cref="IQuestion"/> by <see cref="Guid"/>
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="answer"></param>
        /// <returns>IQuestionBuilder</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
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

        /// <summary>
        /// Add <see cref="IQuestion"/> to internal <see cref="List{T}"/>
        /// </summary>
        /// <param name="question"></param>
        /// <returns>IQuestionBuilder</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IQuestionBuilder AddQuestion(IQuestion question)
        {
            if (question is null)
            {
                throw new ArgumentNullException(nameof(question));
            }

            base.Add(question);

            return this;
        }

        /// <summary>
        /// Return <see cref="List{IQuestion}"/>
        /// </summary>
        /// <returns>List{IQuestion}</returns>
        public List<IQuestion> Create()
        {
            return Items;
        }
        
        /// <summary>
        /// Returns <see cref="IAnswer"/> by <see cref="Guid"/>
        /// </summary>
        /// <param name="answerId"></param>
        /// <returns>IAnswer</returns>
        public IAnswer GetAnswerById(Guid answerId)
        {
            return Items.SelectMany(x => x.Answers).FirstOrDefault(x => x.Id == answerId);
        }

        /// <summary>
        /// Get a <see cref="List{IAnswer}"/> by <see cref="IQuestion"/>
        /// </summary>
        /// <param name="question"></param>
        /// <returns>List{IAnswer}</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public List<IAnswer> GetAnswersByQuestion(IQuestion question)
        {
            if (question is null)
            {
                throw new ArgumentNullException(nameof(question));
            }

            return GetAnswersByQuestionId(question.Id);
        }

        /// <summary>
        /// Get <see cref="List{IAnswer}"/> by <see cref="Guid">Id</see> of <see cref="IQuestion"/> 
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
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

        #endregion
    }
}