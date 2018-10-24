using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using QandA.Core.Questions;
using QandA.Core.Session;
using System;
using System.Collections.Generic;

namespace QandA.Core.Factories
{
    public class QASessionFactory : IQASessionFactory
    {
        #region Private Properties

        private readonly ILogger _logger;

        #endregion Private Properties

        #region Public Constructors

        public QASessionFactory()
        {
            _logger = new NullLogger<IQASessionFactory>();
        }

        public QASessionFactory(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        #endregion

        #region Public Methods

        public IQASession Create(IList<IQuestion> questions)
        {
            _logger.LogInformation("Create", questions);
            return new QASession(questions);
        }

        public IQASession Create(ILogger logger, IList<IQuestion> questions)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            _logger.LogInformation("Create", questions);
            return new QASession(logger, questions);
        }

        public IQASession Create()
        {
            _logger.LogInformation("Create");
            return new QASession();
        }

        #endregion Public Methods
    }
}