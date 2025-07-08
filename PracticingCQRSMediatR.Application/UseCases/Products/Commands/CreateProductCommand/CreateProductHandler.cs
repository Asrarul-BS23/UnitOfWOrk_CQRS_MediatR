
using AutoMapper;
using MediatR;
using PracticingCQRSMediatR.Application.Interfaces;
using PracticingCQRSMediatR.Domain.Models;

namespace PracticingCQRSMediatR.Application.UseCases.Products.Commands.CreateProductCommand;

public class CreateProductHandler: IRequestHandler<CreateProductCommand, string>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<string> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        string response = "Product Added Successfully!";
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var validator = new CreateProductValidator();
            var validationResult = await validator.ValidateAsync(command);
            if(validationResult.Errors.Any())
            {
                response = validationResult.Errors.ToString();
                return response;
            }

            var product = _mapper.Map<Product>(command);
            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();
        }
        catch(Exception ex) 
        {
            response = ex.Message;
            await _unitOfWork.RollbackTransactionAsync();   
        }

        return response;
    }
}
