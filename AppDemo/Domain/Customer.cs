namespace AppDemo.Domain
{
    public class Customer
    {
        public Customer(Guid id, string name, string email)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException($"'{nameof(email)}' cannot be null or whitespace.", nameof(email));
            }

            Id = id;
            Name = name;
            Email = email;
        }
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public void Update(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException($"'{nameof(email)}' cannot be null or whitespace.", nameof(email));
            }

            Name = name;
            Email = email;
        }
    }
}
