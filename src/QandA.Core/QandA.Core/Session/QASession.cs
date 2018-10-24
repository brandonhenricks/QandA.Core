using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using QandA.Core.Answers;
using QandA.Core.Questions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QandA.Core.Session
{
    public class QASession : IQASession
    {
        #region Private Properties

        private readonly ILogger logger;

        #endregion Private Properties

        #region Public Properties

        public Guid SessionId { get; protected set; }

        public IList<IQuestion> ActiveQuestions { get; }

        public DateTime SessionStarted { get; protected set; }

        public DateTime SessionStopped { get; protected set; }

        #endregion Public Properties

        #region Public Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public QASession()
        {
            SessionId = Guid.NewGuid();
            logger = new NullLogger<IQASession>();
        }

        /// <summary>
        /// Constructor that takes an <see cref="ILogger"/> argument.
        /// </summary>
        /// <param name="logger"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public QASession(ILogger logger) : base()
        {
            logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Constructor that takes an <see cref="IList{T}"/> argument.
        /// </summary>
        /// <param name="activeQuestions"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public QASession(IList<IQuestion> activeQuestions) : base()
        {
            ActiveQuestions = activeQuestions ?? throw new ArgumentNullException(nameof(activeQuestions));
        }

        /// <summary>
        /// Constructor that takes an <see cref="ILogger"/> and <see cref="IList{T}"/> arguments.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="activeQuestions"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public QASession(ILogger logger, IList<IQuestion> activeQuestions) : base()
        {
            logger = logger ?? throw new ArgumentNullException(nameof(logger));
            ActiveQuestions = activeQuestions ?? throw new ArgumentNullException(nameof(activeQuestions));
        }

        #endregion Public Constructors

        #region Public Methods

        public string CreateSessionHash()
        {
            logger.LogInformation("CreateSessionHash");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Start a QandA Session.
        /// </summary>
        public void StartSession()
        {
            logger.LogInformation("StartSession");
            SessionStarted = DateTime.UtcNow;
        }

        /// <summary>
        /// Stop a QandA Session.
        /// </summary>
        public void StopSession()
        {
            logger.LogInformation("StopSession");
            SessionStopped = DateTime.UtcNow;
        }

        /// <summary>
        /// Submit an <see cref="IAnswer"/> to a <see cref="IQuestion"/>
        /// </summary>
        /// <param name="question"></param>
        /// <param name="answer"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void TryAnswer(IQuestion question, IAnswer answer)
        {
            logger.LogInformation("TryAnswer", question, answer);

            if (question is null)
            {
                throw new ArgumentNullException(nameof(question));
            }

            if (answer is null)
            {
                throw new ArgumentNullException(nameof(answer));
            }

            question.SubmitAnswer(answer.Id);
        }

        /// <summary>
        /// Submit an <see cref="IAnswer"/> to an <see cref="IQuestion"/>
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="answerId"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void TryAnswer(Guid questionId, Guid answerId)
        {
            logger.LogInformation("TryAnswer", questionId, answerId);

            var question = ActiveQuestions.FirstOrDefault(x => x.Id == questionId);

            if (question is null)
            {
                throw new InvalidOperationException(nameof(questionId));
            }

            question.SubmitAnswer(answerId);
        }

        #endregion Public Methods
    }
}