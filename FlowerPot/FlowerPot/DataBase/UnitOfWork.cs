using FlowerPot.DataBase;
using FlowerPot.Models;
using FlowerPot.Repository;
using System;

namespace FlowerPot.Unit
{
    public class UnitOfWork : IDisposable
    {
        private Context context;
        private Repository<Users> userRepository;
        private Repository<UserAuth> userAuthRepository;
        private Repository<Products> productsRepository;
        private Repository<Color> colorsRepository;
        private Repository<Catagory> categoriesRepository;
        private Repository<Orders> ordersRepository;
        private Repository<Cart> cartRepository;
        private Repository<СonfirmOrder> confOrderRepository;

        public UnitOfWork()
        {
            context = new Context();
        }

        public Repository<Users> UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new Repository<Users>(context);
                return userRepository;
            }
        }

        public Repository<UserAuth> UserAuthRepository
        {
            get
            {
                if (userAuthRepository == null)
                    userAuthRepository = new Repository<UserAuth>(context);
                return userAuthRepository;
            }
        }

        public Repository<Products> ProductsRepository
        {
            get
            {
                if (productsRepository == null)
                    productsRepository = new Repository<Products>(context);
                return productsRepository;
            }
        }
        public Repository<Cart> CartRepository
        {
            get
            {
                if (cartRepository == null)
                    cartRepository = new Repository<Cart>(context);
                return cartRepository;
            }
        }

        public Repository<СonfirmOrder> СonfirmOrderRepository
        {
            get
            {
                if (confOrderRepository == null)
                    confOrderRepository = new Repository<СonfirmOrder>(context);
                return confOrderRepository;
            }
        }

        public Repository<Color> ColorsRepository
        {
            get
            {
                if (colorsRepository == null)
                    colorsRepository = new Repository<Color>(context);
                return colorsRepository;
            }
        }

        public Repository<Catagory> СategoriesRepository
        {
            get
            {
                if (categoriesRepository == null)
                    categoriesRepository = new Repository<Catagory>(context);
                return categoriesRepository;
            }
        }

        public Repository<Orders>OrdersRepository
        {
            get
            {
                if (ordersRepository == null)
                    ordersRepository = new Repository<Orders>(context);
                return ordersRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
