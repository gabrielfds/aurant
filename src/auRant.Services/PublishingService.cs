using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using auRant.Core.Entities;
using auRant.Services.Base;
using auRant.Core.DataBase;
using auRant.Core.DataBase.Repositories;
using auRant.Core;
using auRant.Core.Entities.Base;
using auRant.Core.DataBase.Base;

namespace auRant.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T1">Final entity</typeparam>
    /// <typeparam name="T2">publishable entity</typeparam>
    /// <typeparam name="TR">Final repository</typeparam>
    public class PublishingService<T1, T2, TR> : BaseService<T1>
        where T1 : BasePublishableEntity
        where T2 : BasePublishableEntity, IPublishable
        where TR: BaseRepository<T1>, IPublishingRepository<T1>
    {
        IPublishingRepository<T1> publishableRepository = null;
        DraftRepository<T2> draftRepository = null;
        PublicationStatusRepository publicationStatusRepository = null;
        PublicationStatus draftStatus = null;
        PublicationStatus published = null;
        PublicationStatus history = null;

        public PublishingService(DatabaseContext context)
            : base(context)
        {
            this.SetFinalRepository(context);
            this.draftRepository = new DraftRepository<T2>(context);
            this.publicationStatusRepository = new PublicationStatusRepository(context);
            this.draftStatus = this.publicationStatusRepository.GetByName(Constants.PublicationStatusName.DRAFT);
            this.published = this.publicationStatusRepository.GetByName(Constants.PublicationStatusName.PUBLISHED);
            this.history = this.publicationStatusRepository.GetByName(Constants.PublicationStatusName.HISTORY);
        }

        private void SetFinalRepository(DatabaseContext context)
        {
            Type t = typeof(TR);
            Type[] parameters = { typeof(string), typeof(TR) };
            object finalObjectRepository = Activator.CreateInstance(t, new[] { context });
            this.publishableRepository = (TR)finalObjectRepository;
        }

        public IQueryable<T1> GetAllPublishedWidhoutDraft()
        {
            return this.publishableRepository.GetAllPublishedWidhoutDraft();
        }

        public IQueryable<T2> GetAllDrafts()
        {
            return this.draftRepository.GetDrafts();
        }

        public void Delete(int id)
        {
            this.publishableRepository.Delete(id);
            this.publishableRepository.Save();
        }

        public void CreateDraft(T2 draft, T1 original)
        {
            draft.PublicationStatus = draftStatus;
            draft.CreateOriginal(original);
            this.draftRepository.Create(draft);
            this.draftRepository.Save();
        }

        public T2 GetDraftById(int id)
        {
            return (T2)this.draftRepository.GetById(id);
        }

        public void Publish(IPublishable draft, PublicationDelegate method, T1 original)
        {
            method.Invoke((T2)draft, published, original);
            ((T2)draft).PublicationStatus = history;
            this.publishableRepository.Save();
            this.draftRepository.Save();
        }

        public void UpdateDraft(T2 draftReview)
        {
            this.draftRepository.Save();
        }
    }
}
