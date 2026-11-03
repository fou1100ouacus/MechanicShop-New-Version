using System.ComponentModel;
using System.Text.Json.Serialization;
using MechanicShop.Domain.Common.Results.Abstractions;

namespace MechanicShop.Domain.Common.Results;

// this non-generic Result class is used to represent a result 
// that does not have a value, but can still be successful or contain errors.
public static class Result
{
 // Static properties representing different result types.
    public static Success Success => default;
    public static Created Created => default;
    public static Deleted Deleted => default;
    public static Updated Updated => default;
}
// this generic Result class is used to represent a result that has a value of type TValue,
// and can be either successful or contain errors.  
public sealed class Result<TValue> : IResult<TValue>
{// private fields to hold the value and errors.
    private readonly TValue? _value = default;

    private readonly List<Error>? _errors = null;

    public bool IsSuccess { get; }

// constructor for the Result class that takes a value,
//  a list of errors, and a success flag.
// the constructor is marked with the JsonConstructor attribute to ==> indicate that it should be used by the JSON serializer.
// it is also marked as obsolete to indicate that it should not be used directly, but only by the serializer.
// if the success flag is true, the value is set and the errors list is empty.
// if the success flag is false, the errors list must be provided and cannot be empty.
    [JsonConstructor]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("For serializer only.", true)]
    public Result(TValue? value, List<Error>? errors, bool isSuccess)
    {
        if (isSuccess)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
            _errors = [];
            IsSuccess = true;
        }
        else
        {
            if (errors == null || errors.Count == 0)
            {
                throw new ArgumentException("Provide at least one error.", nameof(errors));
            }

            _errors = errors;
            _value = default!;
            IsSuccess = false;
        }
    }

    private Result(Error error)
    {
        _errors = [error];
    }

    private Result(List<Error> errors)
    {
        if (errors is null || errors.Count == 0)
        {
            throw new ArgumentException("Cannot create an ErrorOr<TValue> from an empty collection of errors. Provide at least one error.", nameof(errors));
        }

        _errors = errors;

        IsSuccess = false;
    }

// private constructor for the Result class that takes a value 
// and sets the success flag to true.
    private Result(TValue value)
    {
        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        _value = value;

        IsSuccess = true;
    }

    public bool IsError => !IsSuccess;

    public List<Error> Errors => IsError ? _errors! : [];

    public TValue Value => IsSuccess ? _value! : default!;

    public Error TopError => (_errors?.Count > 0) ? _errors[0] : default;

    public TNextValue Match<TNextValue>(Func<TValue, TNextValue> onValue, Func<List<Error>, TNextValue> onError)
        => IsSuccess ? onValue(Value!) : onError(Errors);

    public static implicit operator Result<TValue>(TValue value)
        => new(value);

    public static implicit operator Result<TValue>(Error error)
        => new(error);

    public static implicit operator Result<TValue>(List<Error> errors)
        => new(errors);
}

// record structs representing different result types.
//  the record mean that they are immutable and can be compared by value.
//  the struct means that they are value types and will be allocated on the stack.
// 
public readonly record struct Success;
public readonly record struct Created;
public readonly record struct Deleted;
public readonly record struct Updated;
