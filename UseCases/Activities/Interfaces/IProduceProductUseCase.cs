﻿using CoreBusiness;

namespace UseCases.Activities.Interfaces
{
    public interface IProduceProductUseCase
    {
        Task ExecuteAsync(string productionNumber, Product product, int quantity, string doneBy);
    }
}