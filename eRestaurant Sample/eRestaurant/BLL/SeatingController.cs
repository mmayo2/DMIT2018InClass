using eRestaurant.DAL;
using eRestaurant.Entities;
using eRestaurant.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurant.BLL
{
    [DataObject]
    public class SeatingController
    {
        #region Query Methods
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<SeatingSummary> SeatingByDateTime(DateTime date, TimeSpan time)
        {
            using (var context = new RestaurantContext())
            {
                //Code from my Linq query
                var step1 = from data in context.Tables
                            select new
                            {
                                Table = data.TableNumber,
                                Seating = data.Capacity,
                                Bills = from billing in data.Bills
                                        where billing.BillDate.Year == date.Year
                                            && billing.BillDate.Month == date.Month
                                            && billing.BillDate.Day == date.Day
                                        //    && billing.BillDate.TimeOfDay <= time
                                            && DbFunctions.CreateTime(billing.BillDate.Hour, billing.BillDate.Minute, billing.BillDate.Second) <= time
                                            && (!billing.OrderPaid.HasValue || billing.OrderPaid >= time)
                                        //						    && (!billing.PaidStatus || billing.OrderPaid >= time)
                                        select billing,
                                Reservations = from booking in data.Reservations
                                               from billing in booking.Bills
                                               where billing.BillDate.Year == date.Year
                                            && billing.BillDate.Month == date.Month
                                            && billing.BillDate.Day == date.Day
                                        //    && billing.BillDate.TimeOfDay <= time
                                            && DbFunctions.CreateTime(billing.BillDate.Hour, billing.BillDate.Minute, billing.BillDate.Second) <= time
                                            && (!billing.OrderPaid.HasValue || billing.OrderPaid >= time)
                                        //							&& (!billing.PaidStatus || billing.OrderPaid >= time)
                                               select billing
                            };

                var step2 = from data in step1.ToList()
                            select new
                            {
                                Table = data.Table,
                                Seating = data.Seating,
                                CommonBilling = from info in data.Bills.Union(data.Reservations)
                                                select new // info // changed to get only needed info, not entire entity
                                                {
                                                    BillID = info.BillID,
                                                    BillTotal = info.Items.Sum(bi => bi.Quantity * bi.SalePrice),
                                                    Waiter = info.Waiter.FirstName,
                                                    Reservation = info.Reservation
                                                }
                            };

                var step3 = from data in step2
                            select new
                            {
                                Table = data.Table,
                                Seating = data.Seating,
                                Taken = data.CommonBilling.Count() > 0,
                                CommonBilling = data.CommonBilling.FirstOrDefault()
                            };        

                var step4 = from data in step3
                            select new SeatingSummary()
                            {
                                Table = data.Table,
                                Seating = data.Seating,
                                Taken = data.Taken,
                                BillID = data.Taken ?
                                         data.CommonBilling.BillID
                                       : (int?)null,
                                BillTotal = data.Taken ?
                                            data.CommonBilling.BillTotal
                                          : (decimal?)null,
                                Waiter = data.Taken ?
                                         data.CommonBilling.Waiter
                                          : (string)null,
                                ReservationName = data.Taken ?
                                                  (data.CommonBilling.Reservation != null ?
                                                   data.CommonBilling.Reservation.CustomerName : (string)null)
                                                : (string)null

                                
                            };
                return step4.ToList();
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ReservationCollection> ReservationsByTime(DateTime date)
        {
            using (var context = new RestaurantContext())
            {
                // Copy and paste/adapt code from linq
                var result = from data in context.Reservations
                             where data.ReservationDate.Year == date.Year
                                && data.ReservationDate.Month == date.Month
                                && data.ReservationDate.Day == date.Day
                                && data.ReservationStatus == Reservation.Booked //Reservation.Booked
                             select new ReservationSummary()
                             {
                                 Name = data.CustomerName,
                                 Date = data.ReservationDate,
                                 NumberInParty = data.NumberInParty,
                                 Status = data.ReservationStatus,
                                 Event = data.Event.Description,
                                 Contact = data.ContactPhone,
                                 Tables = from seat in data.Tables
                                          select seat.TableNumber
                             };
                var finalResult = from item in result
                                  orderby item.NumberInParty
                                  group item by item.Date.Hour into itemGroup
                                  select new ReservationCollection()
                                  {
                                      Time = itemGroup.Key,
                                      Reservations = itemGroup.ToList()
                                  };
                return finalResult.OrderBy(x => x.Time).ToList();
            }
        }
        #endregion
    }
}
