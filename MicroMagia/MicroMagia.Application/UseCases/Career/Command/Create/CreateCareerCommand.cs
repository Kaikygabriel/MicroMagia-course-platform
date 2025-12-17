using MediatR;
using MicroMagia.Application.DTOs.Career;

namespace MicroMagia.Application.UseCases.Career.Command.Create;

public record CreateCareerCommand(CareerCreateDto Career) : IRequest<bool>;