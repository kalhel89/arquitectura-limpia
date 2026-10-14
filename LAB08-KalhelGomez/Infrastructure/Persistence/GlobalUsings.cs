// Keep the existing composition root and legacy Services compiling while
// AppDbContext lives in the infrastructure persistence namespace.
global using LAB08_KalhelGomez.Infrastructure.Persistence;
global using LAB08_KalhelGomez.Models;
global using LAB08_KalhelGomez.Domain.Entities;
