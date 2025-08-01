﻿using AirlineBookingSystem.Payments.Core.Entities;
using AirlineBookingSystem.Payments.Core.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Payments.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IDbConnection _dbConnection;

        public PaymentRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task ProcessPaymentAsync(Payment payment)
        {
            const string sql = @"
            INSERT INTO Payments (Id, BookingId, Amount, PaymentDate)
            VALUES (@Id, @BookingId, @Amount, @PaymentDate)";
            await _dbConnection.ExecuteAsync(sql, payment);
        }

        public async Task RefundPaymentASync(Guid id)
        {
            const string sql = "DELETE FROM Payments WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
