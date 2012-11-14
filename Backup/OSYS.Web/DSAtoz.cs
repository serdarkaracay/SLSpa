
namespace OSYS.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // Implements application logic using the AtoZCapriceEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class DSAtoz : LinqToEntitiesDomainService<AtoZCapriceEntities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SPA_Diagnosis' query.
        public IQueryable<SPA_Diagnosis> GetSPA_Diagnosis()
        {
            return this.ObjectContext.SPA_Diagnosis;
        }

        public void InsertSPA_Diagnosis(SPA_Diagnosis sPA_Diagnosis)
        {
            if ((sPA_Diagnosis.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sPA_Diagnosis, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SPA_Diagnosis.AddObject(sPA_Diagnosis);
            }
        }

        public void UpdateSPA_Diagnosis(SPA_Diagnosis currentSPA_Diagnosis)
        {
            this.ObjectContext.SPA_Diagnosis.AttachAsModified(currentSPA_Diagnosis, this.ChangeSet.GetOriginal(currentSPA_Diagnosis));
        }

        public void DeleteSPA_Diagnosis(SPA_Diagnosis sPA_Diagnosis)
        {
            if ((sPA_Diagnosis.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sPA_Diagnosis, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.SPA_Diagnosis.Attach(sPA_Diagnosis);
                this.ObjectContext.SPA_Diagnosis.DeleteObject(sPA_Diagnosis);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SPA_GuestDiagnosisDetail' query.
        public IQueryable<SPA_GuestDiagnosisDetail> GetSPA_GuestDiagnosisDetail()
        {
            return this.ObjectContext.SPA_GuestDiagnosisDetail;
        }

        public void InsertSPA_GuestDiagnosisDetail(SPA_GuestDiagnosisDetail sPA_GuestDiagnosisDetail)
        {
            if ((sPA_GuestDiagnosisDetail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sPA_GuestDiagnosisDetail, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SPA_GuestDiagnosisDetail.AddObject(sPA_GuestDiagnosisDetail);
            }
        }

        public void UpdateSPA_GuestDiagnosisDetail(SPA_GuestDiagnosisDetail currentSPA_GuestDiagnosisDetail)
        {
            this.ObjectContext.SPA_GuestDiagnosisDetail.AttachAsModified(currentSPA_GuestDiagnosisDetail, this.ChangeSet.GetOriginal(currentSPA_GuestDiagnosisDetail));
        }

        public void DeleteSPA_GuestDiagnosisDetail(SPA_GuestDiagnosisDetail sPA_GuestDiagnosisDetail)
        {
            if ((sPA_GuestDiagnosisDetail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sPA_GuestDiagnosisDetail, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.SPA_GuestDiagnosisDetail.Attach(sPA_GuestDiagnosisDetail);
                this.ObjectContext.SPA_GuestDiagnosisDetail.DeleteObject(sPA_GuestDiagnosisDetail);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SPA_PersonelDetail' query.
        public IQueryable<SPA_PersonelDetail> GetSPA_PersonelDetail()
        {
            return this.ObjectContext.SPA_PersonelDetail;
        }

        public void InsertSPA_PersonelDetail(SPA_PersonelDetail sPA_PersonelDetail)
        {
            if ((sPA_PersonelDetail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sPA_PersonelDetail, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SPA_PersonelDetail.AddObject(sPA_PersonelDetail);
            }
        }

        public void UpdateSPA_PersonelDetail(SPA_PersonelDetail currentSPA_PersonelDetail)
        {
            this.ObjectContext.SPA_PersonelDetail.AttachAsModified(currentSPA_PersonelDetail, this.ChangeSet.GetOriginal(currentSPA_PersonelDetail));
        }

        public void DeleteSPA_PersonelDetail(SPA_PersonelDetail sPA_PersonelDetail)
        {
            if ((sPA_PersonelDetail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sPA_PersonelDetail, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.SPA_PersonelDetail.Attach(sPA_PersonelDetail);
                this.ObjectContext.SPA_PersonelDetail.DeleteObject(sPA_PersonelDetail);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SPA_PersonelJob' query.
        public IQueryable<SPA_PersonelJob> GetSPA_PersonelJob()
        {
            return this.ObjectContext.SPA_PersonelJob;
        }

        public void InsertSPA_PersonelJob(SPA_PersonelJob sPA_PersonelJob)
        {
            if ((sPA_PersonelJob.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sPA_PersonelJob, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SPA_PersonelJob.AddObject(sPA_PersonelJob);
            }
        }

        public void UpdateSPA_PersonelJob(SPA_PersonelJob currentSPA_PersonelJob)
        {
            this.ObjectContext.SPA_PersonelJob.AttachAsModified(currentSPA_PersonelJob, this.ChangeSet.GetOriginal(currentSPA_PersonelJob));
        }

        public void DeleteSPA_PersonelJob(SPA_PersonelJob sPA_PersonelJob)
        {
            if ((sPA_PersonelJob.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sPA_PersonelJob, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.SPA_PersonelJob.Attach(sPA_PersonelJob);
                this.ObjectContext.SPA_PersonelJob.DeleteObject(sPA_PersonelJob);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SPA_PersonelJobDetail' query.
        public IQueryable<SPA_PersonelJobDetail> GetSPA_PersonelJobDetail()
        {
            return this.ObjectContext.SPA_PersonelJobDetail;
        }

        public void InsertSPA_PersonelJobDetail(SPA_PersonelJobDetail sPA_PersonelJobDetail)
        {
            if ((sPA_PersonelJobDetail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sPA_PersonelJobDetail, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SPA_PersonelJobDetail.AddObject(sPA_PersonelJobDetail);
            }
        }

        public void UpdateSPA_PersonelJobDetail(SPA_PersonelJobDetail currentSPA_PersonelJobDetail)
        {
            this.ObjectContext.SPA_PersonelJobDetail.AttachAsModified(currentSPA_PersonelJobDetail, this.ChangeSet.GetOriginal(currentSPA_PersonelJobDetail));
        }

        public void DeleteSPA_PersonelJobDetail(SPA_PersonelJobDetail sPA_PersonelJobDetail)
        {
            if ((sPA_PersonelJobDetail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sPA_PersonelJobDetail, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.SPA_PersonelJobDetail.Attach(sPA_PersonelJobDetail);
                this.ObjectContext.SPA_PersonelJobDetail.DeleteObject(sPA_PersonelJobDetail);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SPA_PersonelTherapyDetail' query.
        public IQueryable<SPA_PersonelTherapyDetail> GetSPA_PersonelTherapyDetail()
        {
            return this.ObjectContext.SPA_PersonelTherapyDetail;
        }

        public void InsertSPA_PersonelTherapyDetail(SPA_PersonelTherapyDetail sPA_PersonelTherapyDetail)
        {
            if ((sPA_PersonelTherapyDetail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sPA_PersonelTherapyDetail, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SPA_PersonelTherapyDetail.AddObject(sPA_PersonelTherapyDetail);
            }
        }

        public void UpdateSPA_PersonelTherapyDetail(SPA_PersonelTherapyDetail currentSPA_PersonelTherapyDetail)
        {
            this.ObjectContext.SPA_PersonelTherapyDetail.AttachAsModified(currentSPA_PersonelTherapyDetail, this.ChangeSet.GetOriginal(currentSPA_PersonelTherapyDetail));
        }

        public void DeleteSPA_PersonelTherapyDetail(SPA_PersonelTherapyDetail sPA_PersonelTherapyDetail)
        {
            if ((sPA_PersonelTherapyDetail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sPA_PersonelTherapyDetail, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.SPA_PersonelTherapyDetail.Attach(sPA_PersonelTherapyDetail);
                this.ObjectContext.SPA_PersonelTherapyDetail.DeleteObject(sPA_PersonelTherapyDetail);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SPA_RezervationSchedule' query.
        public IQueryable<SPA_RezervationSchedule> GetSPA_RezervationSchedule()
        {
            return this.ObjectContext.SPA_RezervationSchedule;
        }

        public void InsertSPA_RezervationSchedule(SPA_RezervationSchedule sPA_RezervationSchedule)
        {
            if ((sPA_RezervationSchedule.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sPA_RezervationSchedule, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SPA_RezervationSchedule.AddObject(sPA_RezervationSchedule);
            }
        }

        public void UpdateSPA_RezervationSchedule(SPA_RezervationSchedule currentSPA_RezervationSchedule)
        {
            this.ObjectContext.SPA_RezervationSchedule.AttachAsModified(currentSPA_RezervationSchedule, this.ChangeSet.GetOriginal(currentSPA_RezervationSchedule));
        }

        public void DeleteSPA_RezervationSchedule(SPA_RezervationSchedule sPA_RezervationSchedule)
        {
            if ((sPA_RezervationSchedule.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sPA_RezervationSchedule, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.SPA_RezervationSchedule.Attach(sPA_RezervationSchedule);
                this.ObjectContext.SPA_RezervationSchedule.DeleteObject(sPA_RezervationSchedule);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SPA_Status' query.
        public IQueryable<SPA_Status> GetSPA_Status()
        {
            return this.ObjectContext.SPA_Status;
        }

        public void InsertSPA_Status(SPA_Status sPA_Status)
        {
            if ((sPA_Status.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sPA_Status, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SPA_Status.AddObject(sPA_Status);
            }
        }

        public void UpdateSPA_Status(SPA_Status currentSPA_Status)
        {
            this.ObjectContext.SPA_Status.AttachAsModified(currentSPA_Status, this.ChangeSet.GetOriginal(currentSPA_Status));
        }

        public void DeleteSPA_Status(SPA_Status sPA_Status)
        {
            if ((sPA_Status.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sPA_Status, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.SPA_Status.Attach(sPA_Status);
                this.ObjectContext.SPA_Status.DeleteObject(sPA_Status);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SPA_Therapy' query.
        public IQueryable<SPA_Therapy> GetSPA_Therapy()
        {
            return this.ObjectContext.SPA_Therapy;
        }

        public void InsertSPA_Therapy(SPA_Therapy sPA_Therapy)
        {
            if ((sPA_Therapy.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sPA_Therapy, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SPA_Therapy.AddObject(sPA_Therapy);
            }
        }

        public void UpdateSPA_Therapy(SPA_Therapy currentSPA_Therapy)
        {
            this.ObjectContext.SPA_Therapy.AttachAsModified(currentSPA_Therapy, this.ChangeSet.GetOriginal(currentSPA_Therapy));
        }

        public void DeleteSPA_Therapy(SPA_Therapy sPA_Therapy)
        {
            if ((sPA_Therapy.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sPA_Therapy, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.SPA_Therapy.Attach(sPA_Therapy);
                this.ObjectContext.SPA_Therapy.DeleteObject(sPA_Therapy);
            }
        }

        public IQueryable<SPA_Therapy> GetTherapyByID(int ID)
        {
            return this.ObjectContext.SPA_Therapy.Where(t => t.ID == ID);
        }
    }
}


