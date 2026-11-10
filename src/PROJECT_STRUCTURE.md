
|   PROJECT_STRUCTURE.md
+---MechanicShop.Api
|   |   appsettings.Development.json
|   |   appsettings.json
|   |   DependencyInjection.cs
|   |   Dockerfile
|   |   IAssemblyMarker.cs
|   |   Identity.http
|   |   MechanicShop.Api.csproj
|   |   MechanicShop.Api.http
|   |   Program.cs
|   |   
|   |       |   |   appsettings.Development.json
|   |       |   |   appsettings.json
|   |       |   |   libman.json
|   |       |   |   MechanicShop.Api.deps.json
|   |       |   |   MechanicShop.Api.exe
|   |       |   |   MechanicShop.Api.runtimeconfig.json
|   |       |   |   MechanicShop.Client.runtimeconfig.json
|   |       |   |   
||   +---Components
|   |   |   App.razor
|   |   |   _Imports.razor
|   |   |   
|   |   \---Pages
|   |           Error.razor
|   |           
|   +---Controllers
|   |       ApiController.cs
|   |       CustomersController.cs
|   |       DashboardController.cs
|   |       IdentityController.cs
|   |       InvoicesController.cs
|   |       LaborsController.cs
|   |       RepairTasksController.cs
|   |       SettingsController.cs
|   |       WorkOrdersController.cs
|   |       
|   +---Endpoints
|   |       BillingEndpoints.cs
|   |       CustomerEndpoints.cs
|   |       DashboardEndpoints.cs
|   |       IdentityEndpoints.cs
|   |       LaborEndpoints.cs
|   |       RepairTaskEndpoints.cs
|   |       SettingsEndpoints.cs
|   |       WorkOrderEndpoints.cs
|   |       
|   +---Extensions
|   |       ProblemExtensions.cs
|   |       
|   +---Infrastructure
|   |       GlobalExceptionHandler.cs
|   |       RequestLogContextMiddleware.cs
StaticWebAssetEndpoints.props
|   |       |           
|   |           |   .NETCoreApp,Version=v9.0.AssemblyAttributes.cs
|   |           |   
|   |           +---ref
|   +---OpenApi
|   |   \---Transformers
|   |           BearerSecurityOperationTransformer.cs
|   |           BearerSecuritySchemeTransformer.cs
|   |           VersionInfoTransformer.cs
|   |           
|   +---Properties
|   |       launchSettings.json
|   |       
|   +---Services
|   |       CurrentUser.cs
|   |       
|   \---wwwroot
|           app.css
|           favicon.png
|           
+---MechanicShop.Application
|   |   DependencyInjection.cs
|   |   MechanicShop.Application.csproj
|   |   
|   +---Common
|   |   +---Behaviours
|   |   |       CachingBehavior.cs
|   |   |       LoggingBehaviour.cs
|   |   |       PerformanceBehaviour.cs
|   |   |       UnhandledExceptionBehaviour.cs
|   |   |       ValidationBehavior.cs
|   |   |       
|   |   +---Errors
|   |   |       ApplicationErrors.cs
|   |   |       
|   |   +---Interfaces
|   |   |       IAppDbContext.cs
|   |   |       ICachedQuery.cs
|   |   |       IIdentityService.cs
|   |   |       IInvoicePdfGenerator.cs
|   |   |       INotificationService.cs
|   |   |       ITokenProvider.cs
|   |   |       IUser.cs
|   |   |       IWorkOrderNotifier.cs
|   |   |       IWorkOrderPolicy.cs
|   |   |       UtilityService.cs
|   |   |       
|   |   \---Models
|   |           PaginatedList.cs
|   |           
|   +---Features
|   |   +---Billing
|   |   |   +---Commands
|   |   |   |   +---IssueInvoice
|   |   |   |   |       IssueInvoiceCommand.cs
|   |   |   |   |       IssueInvoiceCommandHandler.cs
|   |   |   |   |       IssueInvoiceCommandValidator.cs
|   |   |   |   |       
|   |   |   |   \---SettleInvoice
|   |   |   |           SettleInvoiceCommand.cs
|   |   |   |           SettleInvoiceCommandHandler.cs
|   |   |   |           SettleInvoiceCommandValidator.cs
|   |   |   |           
|   |   |   +---Dtos
|   |   |   |       InvoiceDto.cs
|   |   |   |       InvoiceLineItemDto.cs
|   |   |   |       InvoicePdfDto.cs
|   |   |   |       
|   |   |   +---Mappers
|   |   |   |       InvoiceMapper.cs
|   |   |   |       
|   |   |   \---Queries
|   |   |       +---GetInvoiceById
|   |   |       |       GetInvoiceByIdQuery.cs
|   |   |       |       GetInvoiceByIdQueryHandler.cs
|   |   |       |       GetInvoiceByIdQueryValidator.cs
|   |   |       |       
|   |   |       \---GetInvoicePdf
|   |   |               GetInvoicePdfQuery.cs
|   |   |               GetInvoicePdfQueryValidator.cs
|   |   |               GetInvoicePdfQureyHandler.cs
|   |   |               
|   |   +---Customers
|   |   |   +---Commands
|   |   |   |   +---CreateCustomer
|   |   |   |   |       CreateCustomerCommand.cs
|   |   |   |   |       CreateCustomerCommandHandler.cs
|   |   |   |   |       CreateCustomerCommandValidator.cs
|   |   |   |   |       CreateVehicleCommand.cs
|   |   |   |   |       CreateVehicleCommandValidator.cs
|   |   |   |   |       
|   |   |   |   +---RemoveCustomer
|   |   |   |   |       RemoveCustomerCommand.cs
|   |   |   |   |       RemoveCustomerCommandHandler.cs
|   |   |   |   |       RemoveCustomerCommandValidator.cs
|   |   |   |   |       
|   |   |   |   \---UpdateCustomer
|   |   |   |           UpdateCustomerCommand.cs
|   |   |   |           UpdateCustomerCommandHandler.cs
|   |   |   |           UpdateCustomerCommandValidator.cs
|   |   |   |           UpdateVehicleCommand.cs
|   |   |   |           UpdateVehicleCommandValidator.cs
|   |   |   |           
|   |   |   +---Dtos
|   |   |   |       CustomerDto.cs
|   |   |   |       VehicleDto.cs
|   |   |   |       
|   |   |   +---Mappers
|   |   |   |       CustomerMapper.cs
|   |   |   |       
|   |   |   \---Queries
|   |   |       +---GetCustomerById
|   |   |       |       GetCustomerByIdQuery.cs
|   |   |       |       GetCustomerByIdQueryHandler.cs
|   |   |       |       GetCustomerByIdQueryValidator.cs
|   |   |       |       
|   |   |       \---GetCustomers
|   |   |               GetCustomersQuery.cs
|   |   |               GetCustomersQueryHandler.cs
|   |   |               
|   |   +---Dashboard
|   |   |   +---Dtos
|   |   |   |       TodayWorkOrderStatsDto.cs
|   |   |   |       
|   |   |   \---Queries
|   |   |       \---GetWorkOrderStats
|   |   |               GetWorkOrderStatsQuery.cs
|   |   |               GetWorkOrderStatsQueryHandler.cs
|   |   |               GetWorkOrderStatsQueryValidator.cs
|   |   |               
|   |   +---Identity
|   |   |   |   TokenResponse.cs
|   |   |   |   
|   |   |   +---Dtos
|   |   |   |       AppUserDto.cs
|   |   |   |       
|   |   |   \---Queries
|   |   |       +---GenerateTokens
|   |   |       |       GenerateTokenQuery.cs
|   |   |       |       GenerateTokenQueryHandler.cs
|   |   |       |       GenerateTokenQueryValidator.cs
|   |   |       |       
|   |   |       +---GetUserInfo
|   |   |       |       GetUserByIdQuery.cs
|   |   |       |       GetUserByIdQueryHanlder.cs
|   |   |       |       
|   |   |       \---RefreshTokens
|   |   |               RefreshTokenQuery.cs
|   |   |               RefreshTokenQueryHandler.cs
|   |   |               
|   |   +---Labors
|   |   |   +---Dtos
|   |   |   |       LaborDto.cs
|   |   |   |       
|   |   |   +---Mappers
|   |   |   |       LaborMapper.cs
|   |   |   |       
|   |   |   \---Queries
|   |   |       \---GetLabors
|   |   |               GetLaborsQuery.cs
|   |   |               GetLaborsQueryHandler.cs
|   |   |               
|   |   +---RepairTasks
|   |   |   +---Commands
|   |   |   |   +---CreateRepairTask
|   |   |   |   |       CreateRepairTaskCommand.cs
|   |   |   |   |       CreateRepairTaskCommandHandler.cs
|   |   |   |   |       CreateRepairTaskCommandValidator.cs
|   |   |   |   |       CreateRepairTaskPartCommand.cs
|   |   |   |   |       CreateRepairTaskPartCommandValidator.cs
|   |   |   |   |       
|   |   |   |   +---RemoveRepairTask
|   |   |   |   |       RemoveRepairTaskCommand.cs
|   |   |   |   |       RemoveRepairTaskCommandHandler.cs
|   |   |   |   |       
|   |   |   |   \---UpdateRepairTask
|   |   |   |           UpdateRepairTaskCommand.cs
|   |   |   |           UpdateRepairTaskCommandHandler.cs
|   |   |   |           UpdateRepairTaskCommandValidator.cs
|   |   |   |           UpdateRepairTaskPartCommand.cs
|   |   |   |           UpdateRepairTaskPartCommandValidator.cs
|   |   |   |           
|   |   |   +---Dtos
|   |   |   |       PartDto.cs
|   |   |   |       RepairTaskDto.cs
|   |   |   |       
|   |   |   +---Mappers
|   |   |   |       RepairTaskMapper.cs
|   |   |   |       
|   |   |   \---Queries
|   |   |       +---GetRepairTaskById
|   |   |       |       GetRepairTaskByIdQuery.cs
|   |   |       |       GetRepairTaskByIdQueryHandler.cs
|   |   |       |       GetRepairTaskByIdQueryValidator.cs
|   |   |       |       
|   |   |       \---GetRepairTasks
|   |   |               GetRepairTasksQuery.cs
|   |   |               GetRepairTasksQueryHandler.cs
|   |   |               
|   |   +---Scheduling
|   |   |   +---Dtos
|   |   |   |       AvailabilitySlotDto.cs
|   |   |   |       ScheduleDto.cs
|   |   |   |       SpotDto.cs
|   |   |   |       
|   |   |   \---Queries
|   |   |       \---GetDailyScheduleQuery
|   |   |               GetDailyScheduleQuery.cs
|   |   |               GetDailyScheduleQueryHandler.cs
|   |   |               
|   |   \---WorkOrders
|   |       +---Commands
|   |       |   +---AssignLabor
|   |       |   |       AssignLaborCommand.cs
|   |       |   |       AssignLaborCommandHandler.cs
|   |       |   |       AssignLaborCommandValidator.cs
|   |       |   |       
|   |       |   +---CreateWorkOrder
|   |       |   |       CreateWorkOrderCommand.cs
|   |       |   |       CreateWorkOrderCommandHandler.cs
|   |       |   |       CreateWorkOrderCommandValidator.cs
|   |       |   |       
|   |       |   +---DeleteWorkOrder
|   |       |   |       DeleteWorkOrderCommand.cs
|   |       |   |       DeleteWorkOrderCommandHandler.cs
|   |       |   |       DeleteWorkOrderCommandValidator.cs
|   |       |   |       
|   |       |   +---RelocateWorkOrder
|   |       |   |       RelocateWorkOrderCommand.cs
|   |       |   |       RelocateWorkOrderCommandHandler.cs
|   |       |   |       RescheduleAppointmentCommandValidator.cs
|   |       |   |       
|   |       |   +---UpdateOrderState
|   |       |   |       UpdateWorkOrderStateCommand.cs
|   |       |   |       UpdateWorkOrderStateCommandHandler.cs
|   |       |   |       UpdateWorkOrderStateCommandValidator.cs
|   |       |   |       
|   |       |   \---UpdateWorkOrderRepairTasks
|   |       |           UpdateWorkOrderRepairTasksCommand.cs
|   |       |           UpdateWorkOrderRepairTasksCommandHandler.cs
|   |       |           UpdateWorkOrderRepairTasksCommandValidator.cs
|   |       |           
|   |       +---Dtos
|   |       |       WorkOrderDto.cs
|   |       |       WorkOrderListItemDto.cs
|   |       |       
|   |       +---EventHandlers
|   |       |       SendWorkOrderCompletedEmailHandler.cs
|   |       |       WorkOrderCollectionModifiedEventHandler.cs
|   |       |       
|   |       +---Mappers
|   |       |       WorkOrderMapper.cs
|   |       |       
|   |       \---Queries
|   |           +---GetWorkOrderByIdQuery
|   |           |       GetAppointmentByIdQueryValidator.cs
|   |           |       GetWorkOrderByIdQuery.cs
|   |           |       GetWorkOrderByIdQueryHandler.cs
|   |           |       
|   |           \---GetWorkOrders
|   |                   GetWorkOrdersQuery.cs
|   |                   GetWorkOrdersQueryHandler.cs
|   |                   
|       |   project.assets.json
|       |   
|           |   |   .NETCoreApp,Version=v10.0.AssemblyAttributes.cs
|           |   |   Mechanic.B1FFC696.Up2Date
|           |   |   
|           |   +---ref
|           |   |       
|           |           
|               |   .NETCoreApp,Version=v9.0.AssemblyAttributes.cs
|               |   Mechanic.B1FFC696.Up2Date
|               |   
|               +---ref
|               |       
|                       
+---MechanicShop.Client
|   |   libman.json
|   |   MechanicShop.Client.csproj
|   |   Program.cs
|   |   Routes.razor
|   |   _Imports.razor
|   |   
|   |       |   |   icudt_CJK.dat
|   |       |   |   icudt_EFIGS.dat
|   |       |   |   icudt_no_CJK.dat
|   |       |   |   libman.json
|   |       |   |   MechanicShop.Client.runtimeconfig.json
|   |       |   |   
||   +---Common
|   |       UIHelper.cs
|   |       
|   +---Components
|   |       Dashboard.razor
|   |       Dashboard.razor.css
|   |       LandingPage.razor
|   |       LandingPage.razor.css
|   |       SpotComponent.razor
|   |       TemplatedDialog.razor
|   |       TemplatedDialog.razor.css
|   |       TimeSlotDisplayComponent.razor
|   |       
|   +---Extensions
|   |       ProblemDetailsExtensions.cs
|   |       WorkOrderExtensions.cs
|   |       
|   +---Hubs
|   |       WorkOrderHubClient.cs
|   |       
|   +---Identity
|   |       BearerTokenHandler.cs
|   |       CustomAuthenticationStateProvider.cs
|   |       FormResult.cs
|   |       IAccountManagement.cs
|   |       RoleClaim.cs
|   |       TokenResponse.cs
|   |       UserInfo.cs
|   |       
|   +---Layout
|   |       MainLayout.razor
|   |       MainLayout.razor.css
|   |       
|   +---Models
|   |       AvailabilitySlotModel.cs
|   |       CustomerModel.cs
|   |       InvoiceLineItemModel.cs
|   |       InvoiceModel.cs
|   |       LaborModel.cs
|   |       PaginatedList.cs
|   |       PartModel.cs
|   |       ProblemDetails.cs
|   |       RepairTaskModel.cs
|   |       ScheduleModel.cs
|   |       SpotModel.cs
|   |       TodayWorkOrderStatsModel.cs
|   |       VehicleModel.cs
|   |       WorkOrderListItemModel.cs
|   |       WorkOrderModel.cs
|   |       
|   |   |   project.assets.json
|   |   |   
|   |       |   |   .NETCoreApp,Version=v10.0.AssemblyAttributes.cs
|   |       |   |   blazor.build.boot-extension.json
|   |       |   |   EmbeddedAttribute.cs
|   |       |   |   Mechanic.52B93595.Up2Date
|   |       |   |   ValidatableTypeAttribute.cs
|   |       |   |   
|   |       |   +---ref
|   |       |   |       
|   |       |   |       
|   |       |   +---scopedcss
|   |       |   |   +---bundle
|   |       |   |   |       MechanicShop.Client.styles.css
|   |       |   |   |       
|   |       |   |   +---Components
|   |       |   |   |       Dashboard.razor.rz.scp.css
|   |       |   |   |       LandingPage.razor.rz.scp.css
|   |       |   |   |       TemplatedDialog.razor.rz.scp.css
|   |       |   |   |       
|   |       |   |   +---Layout
|   |       |   |   |       MainLayout.razor.rz.scp.css
|   |       |   |   |       
|   |       |   |   +---Pages
|   |       |   |   |   +---DailySchedule
|   |       |   |   |   |   +---Components
|   |       |   |   |   |   |       AvailabilitySlotComponent.razor.rz.scp.css
|   |       |   |   |   |   |       EditWorkOrderStateDialog.razor.rz.scp.css
|   |       |   |   |   |   |       
|   |       |   |   |   |   \---Pages
|   |       |   |   |   |           Schedules.razor.rz.scp.css
|   |       |   |   |   |           
|   |       |   |   |   \---RepairTasks
|   |       |   |   |       \---Pages
|   |       |   |   |               RepairTaskList.razor.rz.scp.css
|   |       |   |   |               
|   |       |   |   \---projectbundle
|   |       |   |           MechanicShop.Client.bundle.scp.css
|   |       |   |           
|   |                       
|   +---Pages
|   |   |   Home.razor
|   |   |   
|   |   +---Accounts
|   |   |       Login.razor
|   |   |       Logout.razor
|   |   |       
|   |   +---Billing
|   |   |   \---Pages
|   |   |           InvoiceDetails.razor
|   |   |           
|   |   +---Common
|   |   |       Paginator.razor
|   |   |       
|   |   +---Customers
|   |   |   \---Pages
|   |   |           CustomersList.razor
|   |   |           
|   |   +---DailySchedule
|   |   |   +---Components
|   |   |   |       AvailabilitySlotComponent.razor
|   |   |   |       AvailabilitySlotComponent.razor.css
|   |   |   |       EditWorkOrderLaborDialog.razor
|   |   |   |       EditWorkOrderRepairTaskDialog.razor
|   |   |   |       EditWorkOrderStateDialog.razor
|   |   |   |       EditWorkOrderStateDialog.razor.css
|   |   |   |       RelocateWorkOrderDialog.razor
|   |   |   |       RepairTaskSelector.razor
|   |   |   |       TimeSlotMarker.razor
|   |   |   |       WorkOrderForm.razor
|   |   |   |       
|   |   |   \---Pages
|   |   |           Schedules.razor
|   |   |           Schedules.razor.css
|   |   |           
|   |   +---RepairTasks
|   |   |   \---Pages
|   |   |           RepairTaskList.razor
|   |   |           RepairTaskList.razor.css
|   |   |           
|   |   \---WorkOrders
|   |       \---Pages
|   |               WorkOrderDetails.razor
|   |               WorkOrderList.razor
|   |               
|   +---Properties
|   |       launchSettings.json
|   |       
|   +---Services
|   |       ApiResult.cs
|   |       ServiceApi.cs
|   |       TimeZoneService.cs
|   |       
|   \---wwwroot
|           appsettings.Development.json
|           appsettings.json
|           
+---MechanicShop.Contracts
|   |   MechanicShop.Contracts.csproj
|   |   
|   |       |       MechanicShop.Contracts.deps.json
|   |       |       
|   |               MechanicShop.Contracts.deps.json
|   |               
|   +---Common
|   |       InvoiceStatus.cs
|   |       RepairDurationInMinutes.cs
|   |       Spot.cs
|   |       WorkOrderState.cs
|   |       
|   |   |   project.assets.json
|   |   |   
|   |       |   |   .NETCoreApp,Version=v10.0.AssemblyAttributes.cs
|   |       |   |   
|   |       |   +---ref
|   |       |   |       
|   |       |           
|   |           |   .NETCoreApp,Version=v9.0.AssemblyAttributes.cs
|   |           |   
|   |           +---ref
|   |           |       
|   |                   
|   +---Requests
|   |   +---Customers
|   |   |       CreateCustomerRequest.cs
|   |   |       CreateVehicleRequest.cs
|   |   |       UpdateCustomerRequest.cs
|   |   |       UpdateVehicleRequest.cs
|   |   |       
|   |   +---RepairTasks
|   |   |       CreateRepairTaskPartRequest.cs
|   |   |       CreateRepairTaskRequest.cs
|   |   |       UpdateRepairTaskPartRequest.cs
|   |   |       UpdateRepairTaskRequest.cs
|   |   |       
|   |   \---WorkOrders
|   |           AssignLaborRequest.cs
|   |           CreateWorkOrderRequest.cs
|   |           LoginRequest.cs
|   |           ModifyRepairTaskRequest.cs
|   |           PageRequest.cs
|   |           RelocateWorkOrderRequest.cs
|   |           UpdateWorkOrderStateRequest.cs
|   |           WorkOrderFilterRequest.cs
|   |           
|   \---Responses
|           OperatingHoursResponse.cs
|           
+---MechanicShop.Domain
|   |   MechanicShop.Domain.csproj
|   |   
|   |       |       MechanicShop.Domain.deps.json
|   |       |       
|   |               MechanicShop.Domain.deps.json
|   |               
|   +---Common
|   |   |   AuditableEntity.cs
|   |   |   DomainEvent.cs
|   |   |   Entity.cs
|   |   |   
|   |   +---Constants
|   |   |       MechanicShopConstants.cs
|   |   |       
|   |   \---Results
|   |       |   Error.cs
|   |       |   ErrorKind.cs
|   |       |   Result.cs
|   |       |   
|   |       \---Abstractions
|   |               IResult.cs
|   |               
|   +---Customers
|   |   |   Customer.cs
|   |   |   CustomerErrors.cs
|   |   |   
|   |   \---Vehicles
|   |           Vehicle.cs
|   |           VehicleErrors.cs
|   |           
|   +---Employees
|   |       Employee.cs
|   |       EmployeeErrors.cs
|   |       
|   +---Identity
|   |       RefreshToken.cs
|   |       RefreshTokenErrors.cs
|   |       Role.cs
|   |       
|   |   |   project.assets.json
|   |   |   
|   |       |   |   .NETCoreApp,Version=v10.0.AssemblyAttributes.cs
|   |       |   |   
|   |       |   +---ref
|   |       |   |       
|   |       |           
|   |           |   .NETCoreApp,Version=v9.0.AssemblyAttributes.cs
|   |           |   
|   |           +---ref
|   |           |       
|   |                   
|   +---RepairTasks
|   |   |   RepairTask.cs
|   |   |   RepairTaskErrors.cs
|   |   |   
|   |   +---Enums
|   |   |       RepairDurationInMinutes.cs
|   |   |       
|   |   \---Parts
|   |           Part.cs
|   |           PartErrors.cs
|   |           
|   \---Workorders
|       |   WorkOrder.cs
|       |   WorkOrderErrors.cs
|       |   
|       +---Billing
|       |       Invoice.cs
|       |       InvoiceErrors.cs
|       |       InvoiceLineItem.cs
|       |       InvoiceLineItemErrors.cs
|       |       InvoiceStatus.cs
|       |       
|       +---Enums
|       |       Spot.cs
|       |       WorkOrderState.cs
|       |       
|       \---Events
|               WorkOrderCollectionModified.cs
|               WorkOrderCompleted.cs
|               
\---MechanicShop.Infrastructure
    |   DependencyInjection.cs
    |   MechanicShop.Infrastructure.csproj
    |   
    +---BackgroundJobs
    |       OverdueBookingCleanupService.cs
    |       
    |       |   |   MechanicShop.Infrastructure.deps.json
    |       |   |   MechanicShop.Infrastructure.runtimeconfig.json
    |       |   |   
    +---Data
    |   |   AppDbContext.cs
    |   |   ApplicationDbContextInitialiser.cs
    |   |   
    |   +---Configurations
    |   |       CustomerConfiguration.cs
    |   |       EmployeeConfiguration.cs
    |   |       InvoiceConfiguration.cs
    |   |       PartConfiguration.cs
    |   |       RefreshTokenConfiguration.cs
    |   |       RepairTaskConfiguration.cs
    |   |       VehicleConfiguration.cs
    |   |       WorkOrderConfiguration.cs
    |   |       
    |   +---Interceptors
    |   |       AuditableEntityInterceptor.cs
    |   |       
    |   \---Migrations
    |           20250701125315_Initial.cs
    |           20250701125315_Initial.Designer.cs
    |           AppDbContextModelSnapshot.cs
    |           
    +---Identity
    |   |   AppUser.cs
    |   |   IdentityService.cs
    |   |   TokenProvider.cs
    |   |   
    |   \---Policies
    |           LaborAssignedRequirement.cs
    |           
    |   |   project.assets.json
    |   |   
    |       |   |   .NETCoreApp,Version=v10.0.AssemblyAttributes.cs
    |       |   |   Mechanic.596B6B0A.Up2Date
    |       |   |   
    |       |   +---ref
    |       |   |       
    |       |           
    |           |   .NETCoreApp,Version=v9.0.AssemblyAttributes.cs
    |           |   Mechanic.596B6B0A.Up2Date
    |           |   
    |           +---ref
    |           |       
    |                   
    +---RealTime
    |       SignalRWorkOrderNotifier.cs
    |       WorkOrderHub.cs
    |       
    +---Services
    |       InvoicePdfGenerator.cs
    |       NotificationService.cs
    |       WorkOrderPolicy.cs
    |       
    \---Settings
            AppSettings.cs
            
