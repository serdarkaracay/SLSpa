
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
    using NUtils.Login.Dto;


    // Implements application logic using the Entities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class DSAtoz : LinqToEntitiesDomainService<Entities>
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
        // To support paging you will need to add ordering to the 'SPA_GuestTherapyDetail' query.
        public IQueryable<SPA_GuestTherapyDetail> GetSPA_GuestTherapyDetail()
        {
            return this.ObjectContext.SPA_GuestTherapyDetail;
        }

        public void InsertSPA_GuestTherapyDetail(SPA_GuestTherapyDetail sPA_GuestTherapyDetail)
        {
            if ((sPA_GuestTherapyDetail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sPA_GuestTherapyDetail, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SPA_GuestTherapyDetail.AddObject(sPA_GuestTherapyDetail);
            }
        }

        public void UpdateSPA_GuestTherapyDetail(SPA_GuestTherapyDetail currentSPA_GuestTherapyDetail)
        {
            this.ObjectContext.SPA_GuestTherapyDetail.AttachAsModified(currentSPA_GuestTherapyDetail, this.ChangeSet.GetOriginal(currentSPA_GuestTherapyDetail));
        }

        public void DeleteSPA_GuestTherapyDetail(SPA_GuestTherapyDetail sPA_GuestTherapyDetail)
        {
            if ((sPA_GuestTherapyDetail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sPA_GuestTherapyDetail, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.SPA_GuestTherapyDetail.Attach(sPA_GuestTherapyDetail);
                this.ObjectContext.SPA_GuestTherapyDetail.DeleteObject(sPA_GuestTherapyDetail);
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
            return this.ObjectContext.SPA_Therapy.OrderBy(t => t.TherapyName);
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

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'View_SPA_GuestDiagnosticDetail' query.
        public IQueryable<View_SPA_GuestDiagnosticDetail> GetView_SPA_GuestDiagnosticDetail()
        {
            return this.ObjectContext.View_SPA_GuestDiagnosticDetail;
        }

        public void InsertView_SPA_GuestDiagnosticDetail(View_SPA_GuestDiagnosticDetail view_SPA_GuestDiagnosticDetail)
        {
            if ((view_SPA_GuestDiagnosticDetail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(view_SPA_GuestDiagnosticDetail, EntityState.Added);
            }
            else
            {
                this.ObjectContext.View_SPA_GuestDiagnosticDetail.AddObject(view_SPA_GuestDiagnosticDetail);
            }
        }

        public void UpdateView_SPA_GuestDiagnosticDetail(View_SPA_GuestDiagnosticDetail currentView_SPA_GuestDiagnosticDetail)
        {
            this.ObjectContext.View_SPA_GuestDiagnosticDetail.AttachAsModified(currentView_SPA_GuestDiagnosticDetail, this.ChangeSet.GetOriginal(currentView_SPA_GuestDiagnosticDetail));
        }

        public void DeleteView_SPA_GuestDiagnosticDetail(View_SPA_GuestDiagnosticDetail view_SPA_GuestDiagnosticDetail)
        {
            if ((view_SPA_GuestDiagnosticDetail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(view_SPA_GuestDiagnosticDetail, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.View_SPA_GuestDiagnosticDetail.Attach(view_SPA_GuestDiagnosticDetail);
                this.ObjectContext.View_SPA_GuestDiagnosticDetail.DeleteObject(view_SPA_GuestDiagnosticDetail);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'View_SPA_GuestReservation' query.
        public IQueryable<View_SPA_GuestReservation> GetView_SPA_GuestReservation()
        {
            return this.ObjectContext.View_SPA_GuestReservation;
        }

        public void InsertView_SPA_GuestReservation(View_SPA_GuestReservation view_SPA_GuestReservation)
        {
            if ((view_SPA_GuestReservation.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(view_SPA_GuestReservation, EntityState.Added);
            }
            else
            {
                this.ObjectContext.View_SPA_GuestReservation.AddObject(view_SPA_GuestReservation);
            }
        }

        public void UpdateView_SPA_GuestReservation(View_SPA_GuestReservation currentView_SPA_GuestReservation)
        {
            this.ObjectContext.View_SPA_GuestReservation.AttachAsModified(currentView_SPA_GuestReservation, this.ChangeSet.GetOriginal(currentView_SPA_GuestReservation));
        }

        public void DeleteView_SPA_GuestReservation(View_SPA_GuestReservation view_SPA_GuestReservation)
        {
            if ((view_SPA_GuestReservation.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(view_SPA_GuestReservation, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.View_SPA_GuestReservation.Attach(view_SPA_GuestReservation);
                this.ObjectContext.View_SPA_GuestReservation.DeleteObject(view_SPA_GuestReservation);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'View_SPA_ReservationList' query.
        public IQueryable<View_SPA_ReservationList> GetView_SPA_ReservationList()
        {
            return this.ObjectContext.View_SPA_ReservationList;
        }

        public void InsertView_SPA_ReservationList(View_SPA_ReservationList view_SPA_ReservationList)
        {
            if ((view_SPA_ReservationList.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(view_SPA_ReservationList, EntityState.Added);
            }
            else
            {
                this.ObjectContext.View_SPA_ReservationList.AddObject(view_SPA_ReservationList);
            }
        }

        public void UpdateView_SPA_ReservationList(View_SPA_ReservationList currentView_SPA_ReservationList)
        {
            this.ObjectContext.View_SPA_ReservationList.AttachAsModified(currentView_SPA_ReservationList, this.ChangeSet.GetOriginal(currentView_SPA_ReservationList));
        }

        public void DeleteView_SPA_ReservationList(View_SPA_ReservationList view_SPA_ReservationList)
        {
            if ((view_SPA_ReservationList.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(view_SPA_ReservationList, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.View_SPA_ReservationList.Attach(view_SPA_ReservationList);
                this.ObjectContext.View_SPA_ReservationList.DeleteObject(view_SPA_ReservationList);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'View_SPA_ScheduleReservation' query.
        public IQueryable<View_SPA_ScheduleReservation> GetView_SPA_ScheduleReservation()
        {
            return this.ObjectContext.View_SPA_ScheduleReservation;
        }

        public void InsertView_SPA_ScheduleReservation(View_SPA_ScheduleReservation view_SPA_ScheduleReservation)
        {
            if ((view_SPA_ScheduleReservation.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(view_SPA_ScheduleReservation, EntityState.Added);
            }
            else
            {
                this.ObjectContext.View_SPA_ScheduleReservation.AddObject(view_SPA_ScheduleReservation);
            }
        }

        public void UpdateView_SPA_ScheduleReservation(View_SPA_ScheduleReservation currentView_SPA_ScheduleReservation)
        {
            this.ObjectContext.View_SPA_ScheduleReservation.AttachAsModified(currentView_SPA_ScheduleReservation, this.ChangeSet.GetOriginal(currentView_SPA_ScheduleReservation));
        }

        public void DeleteView_SPA_ScheduleReservation(View_SPA_ScheduleReservation view_SPA_ScheduleReservation)
        {
            if ((view_SPA_ScheduleReservation.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(view_SPA_ScheduleReservation, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.View_SPA_ScheduleReservation.Attach(view_SPA_ScheduleReservation);
                this.ObjectContext.View_SPA_ScheduleReservation.DeleteObject(view_SPA_ScheduleReservation);
            }
        }

        #region CustomQuerys

        //22.08.2012
        public IQueryable<SPA_Therapy> GetTherapyByID(string ID)
        {
            Guid _id = Guid.Parse(ID);
            return this.ObjectContext.SPA_Therapy.Where(t => t.ID == _id);
        }

        //27.08.2012
        public IQueryable<View_SPA_GuestReservation> GetViewSpaGuestReservation(string roomNumber)
        {
            return this.ObjectContext.View_SPA_GuestReservation.Where(x => x.Number == roomNumber);

        }

        //31.08.2012
        public IQueryable<DTO.DbPersonelJobDetail> GetResourcePersonel()
        {
            IQueryable<DTO.DbPersonelJobDetail> result = (from p in ObjectContext.SPA_PersonelJobDetail
                                                          select new DTO.DbPersonelJobDetail()
                                                          {
                                                              PersonelID = p.PersonelID,
                                                              Adi = p.Adi
                                                          }).Distinct();
            return result.AsQueryable();

        }
        //01.09.2013
        public IQueryable<SPA_Therapy> GetFizyoterapistTherapy()
        {
            return ObjectContext.SPA_Therapy.Where(t => t.Price == 0 || t.Price == null);
        }
        //03.09.2013 -- Fizyoterapiste Kayıtlı Olan Misafirleri getirir.
        public IQueryable<DTO.DbGuest> GetFizyoterapistGuest(string fizyoterapisID)
        {

            Guid _fizyoterapisID = Guid.Parse(fizyoterapisID);
            IQueryable<DTO.DbGuest> result = from p in ObjectContext.SPA_GuestDiagnosisDetail
                                             join c in ObjectContext.View_SPA_GuestReservation on p.GuestID equals c.ID
                                             where (p.Completed == false && p.PersonelID == _fizyoterapisID)
                                             select new DTO.DbGuest
                                             {
                                                 GuestID = p.GuestID,
                                                 RoomNumber = c.Number,
                                                 FirstName = c.FirstName,
                                                 LastName = c.Name,
                                                 GuestName = c.SearchName,
                                                 Arrival = c.ArriveDate,
                                                 Release = c.DepartureDate,
                                                 ID = p.ID
                                             };
            return result.AsQueryable();
        }

        //03.09.2012
        public IQueryable<DTO.DbGuest> GetFizyoterapistGuestByID(string ID)
        {
            Guid _id = Guid.Parse(ID);
            IQueryable<DTO.DbGuest> result = from p in ObjectContext.SPA_GuestDiagnosisDetail
                                             join c in ObjectContext.View_SPA_GuestReservation on p.GuestID equals c.ID
                                             where p.GuestID == _id
                                             select new DTO.DbGuest
                                             {
                                                 GuestID = p.GuestID,
                                                 DiagnosisID = p.DiagnosisID,
                                                 Desc = p.DescDiagnosis,
                                                 RoomNumber = c.Number,
                                                 FirstName = c.FirstName,
                                                 LastName = c.Name,
                                                 GuestName = c.SearchName,
                                                 Arrival = c.ArriveDate,
                                                 Release = c.DepartureDate,
                                                 ID = p.ID

                                             };

            return result.AsQueryable();
        }

        //03.09.2012
        public IQueryable<SPA_GuestDiagnosisDetail> GetFizyoterapistDia(string ID)
        {
            Guid _id = Guid.Parse(ID);
            IQueryable<SPA_GuestDiagnosisDetail> result = from p in ObjectContext.SPA_GuestDiagnosisDetail
                                                          where p.ID == _id
                                                          select p;

            return result.AsQueryable();
        }

        //05.09.2012
        public IQueryable<SPA_GuestDiagnosisDetail> GetDiagnosisDetailUpdate(string ID)
        {
            Guid _id = Guid.Parse(ID);
            IQueryable<SPA_GuestDiagnosisDetail> result = from p in ObjectContext.SPA_GuestDiagnosisDetail
                                                          where p.ID == _id
                                                          select p;
            return result.AsQueryable();
        }


        //06.09.2012
        public IQueryable<View_SPA_GuestDiagnosticDetail> GetFizyoterapistByGuestID(string GuestID)
        {
            Guid _guestID = Guid.Parse(GuestID);
            return ObjectContext.View_SPA_GuestDiagnosticDetail.Where(g => g.GuestID == _guestID);
        }

        //10.09.2012
        public IQueryable<DTO.DbPersonelTherapy> GetPersonelJobByAppointment(string PersonelID)
        {
            Guid _personelID = new Guid(PersonelID);
            IQueryable<DTO.DbPersonelTherapy> results = from p in ObjectContext.SPA_PersonelJobDetail
                                                        join c in ObjectContext.SPA_Therapy on p.TherapyID equals c.ID
                                                        where p.PersonelID == _personelID
                                                        select new DTO.DbPersonelTherapy
                                                        {
                                                            TherapyID = c.ID,
                                                            TherapyName = c.TherapyName

                                                        };
            return results.AsQueryable();
        }

        //17.09.2012
        public IQueryable<SPA_GuestTherapyDetail> GetSpaGuestTherapyDetail(string GuestID, string TherapyID)
        {
            Guid _guestID = Guid.Parse(GuestID);
            Guid _therapyID = Guid.Parse(TherapyID);
            return ObjectContext.SPA_GuestTherapyDetail.Where(x => x.GuestID == _guestID && x.TherapyID == _therapyID);
        }

        //24.09.2012 - Scheduler databinding
        public IQueryable<SPA_RezervationSchedule> GetRezervationScheduleByDatetime(DateTime? dateTime)
        {
            return ObjectContext.SPA_RezervationSchedule.Where(r => r.StartDateTime == (dateTime ?? DateTime.Now.AddDays(1)));
        }

        //28.09.2012 - Izinli Personelleri Scheduler database kayıt eder.
        public IQueryable<DTO.DBIzinPersonel> InsertIzinliPersonel()
        {
            Caprice_OfisEntities capriceOfis = new Caprice_OfisEntities();
            Entities atoz = new Entities();


            var resAtoz = new List<SPA_PersonelJobDetail>(atoz.SPA_PersonelJobDetail);
            var resOfis = new List<View_SPA_PersonelIzin>(capriceOfis.View_SPA_PersonelIzin);
            var resSch = new List<SPA_RezervationSchedule>(atoz.SPA_RezervationSchedule);//todo:gerçek ortama geçince-.Where(x=>x.StartDateTime>DateTime.Now)
            /*select * from personeljobdetail p inner join View_SPA _PersonelIzin c on p.PersonelID = c.OID*/

            var result = from p in resAtoz
                         join c in resOfis on p.PersonelID equals c.OID
                         where !resSch.Any(x => x.IzinID == c.IzinID)
                         select new DTO.DBIzinPersonel
                         {
                             PersonelID = p.PersonelID,
                             IzinID = c.IzinID,
                             BaslangicTarihi = c.BaslangicTarihi ?? DateTime.Now,
                             BitisTarihi = c.BitisTarihi ?? DateTime.Now
                         };
            var list = result.GroupBy(x => x.IzinID).Select(x => x.First()).ToList();


            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    SPA_RezervationSchedule reservation = new SPA_RezervationSchedule();
                    reservation.ID = Guid.NewGuid();
                    reservation.PersonelID = item.PersonelID;
                    reservation.StartDateTime = item.BaslangicTarihi;
                    reservation.EndDateTime = item.BitisTarihi;
                    reservation.StatusID = 5; //İzinli
                    reservation.Subject = "İzinli Personel";
                    reservation.GuestNote = "İzinli Personel";
                    reservation.IzinID = item.IzinID;
                    reservation.Location = "İzinli Personel";
                    ObjectContext.AddToSPA_RezervationSchedule(reservation);
                }
                ObjectContext.SaveChanges();
            }

            return list.AsQueryable();
        }

        public IQueryable<SPA_PersonelJobDetail> GetPersonelDetailList(string ServisID)
        {
            Guid _servisID = Guid.Parse(ServisID);
            return ObjectContext.SPA_PersonelJobDetail.Where(j => j.TherapyID == _servisID);
        }

        public IQueryable<DTO.DBGuestServicePlan> GetGuestServicePlan(string GuestID)
        {
            Guid _guestID = new Guid(GuestID);
            IQueryable<DTO.DBGuestServicePlan> list = from gt in ObjectContext.SPA_GuestTherapyDetail
                                                      join t in ObjectContext.SPA_Therapy on gt.TherapyID equals t.ID
                                                      where gt.IsCompleted == false && gt.GuestID == _guestID
                                                      select new DTO.DBGuestServicePlan
                                                      {
                                                          GuestTherapyID = gt.ID,
                                                          TherapID = gt.TherapyID,
                                                          TherapyName = t.TherapyName,
                                                          TherapyDateTime = gt.TherapyDateTime,
                                                          ServisDesc = gt.TherapyNote
                                                      };

            return list.AsQueryable();
        }

        /// <summary>
        /// ServisID göre PersonelListesi 
        /// </summary>
        /// <param name="therapyID">ServisID</param>
        /// <returns>PersonelList</returns>
        public IQueryable<SPA_PersonelJobDetail> GetPersonelByTherapyID(string therapyID)
        {
            Guid _therapyID = Guid.Parse(therapyID);
            return ObjectContext.SPA_PersonelJobDetail.Where(p => p.TherapyID == _therapyID);
        }

        public IQueryable<SPA_GuestTherapyDetail> GetTherapyGuestDetail(string id)
        {
            Guid _id = Guid.Parse(id);
            return ObjectContext.SPA_GuestTherapyDetail.Where(t => t.ID == _id);
        }

        #region LoginRole


        public DTO.DbLogin LoginRole(string username, string password)
        {

            DTO.DbLogin dbLogin = new DTO.DbLogin();
            Kullanici userLogin;
            string AppName = "Spa";

            NUtils.Login.Authentication newAuthentication = new NUtils.Login.Authentication(AppName);

            try
            {
                userLogin = newAuthentication.KullaniciKontrol(username, password);
                dbLogin.PersonelName = userLogin.AdSoyad;
                dbLogin.PersonelID = userLogin.KullaniciID;
                dbLogin.UserGrup = userLogin.UserRoleAD;
            }
            catch (Exception msg)
            {

            }
            return dbLogin;

        }
        #endregion


        #endregion
    }
}


