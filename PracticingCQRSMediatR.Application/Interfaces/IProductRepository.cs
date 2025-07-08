using PracticingCQRSMediatR.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticingCQRSMediatR.Application.Interfaces;

public interface IProductRepository: IGenericRepository<Product>
{
}
