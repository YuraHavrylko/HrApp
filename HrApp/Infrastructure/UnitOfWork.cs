using HrApp.Repositories;

namespace HrApp.Infrastructure
{
    public class UnitOfWork
    {
        public PersonRepository PersonRepository { get; private set; }
        public LanguageRepository LanguageRepository { get; private set; }
        public ProfessionalSkillRepository ProfessionalSkillRepository { get; private set; }
        public EducationRepository EducationRepository { get; private set; }
        public JobRepository JobRepository { get; private set; }
        public TypeJobRepository TypeJobRepository { get; private set; }
        public WorkExpireanceRepository WorkExpireanceRepository { get; private set; }
        public InterviewRepository InterviewRepository { get; private set; }
        public TypeLanguageRepository LanguagesNameRepository { get; private set; }
        public LanguageLevelRepository LanguageLevelRepository { get; private set; }
        public TypeJobsNameRepository TypeJobsNameRepository { get; private set; }

        public UnitOfWork(string connection)
        {
            PersonRepository = new PersonRepository(new DbConnectionFactory(connection));
            LanguageRepository = new LanguageRepository(new DbConnectionFactory(connection));
            ProfessionalSkillRepository = new ProfessionalSkillRepository(new DbConnectionFactory(connection));
            EducationRepository = new EducationRepository(new DbConnectionFactory(connection));
            JobRepository = new JobRepository(new DbConnectionFactory(connection));
            TypeJobRepository = new TypeJobRepository(new DbConnectionFactory(connection));
            WorkExpireanceRepository = new WorkExpireanceRepository(new DbConnectionFactory(connection));
            InterviewRepository = new InterviewRepository(new DbConnectionFactory(connection));
            LanguagesNameRepository = new TypeLanguageRepository(new DbConnectionFactory(connection));
            LanguageLevelRepository = new LanguageLevelRepository(new DbConnectionFactory(connection));
            TypeJobsNameRepository = new TypeJobsNameRepository(new DbConnectionFactory(connection));
        }
    }
}