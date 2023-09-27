using Microsoft.EntityFrameworkCore;

public class SchoolDbContext : DbContext
{
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Pupil> Pupils { get; set; }
    public DbSet<TeacherPupil> TeacherPupils { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("your_connection_string_here");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TeacherPupil>(entity =>
        {
            entity.HasKey(e => new { e.TeacherID, e.PupilID });

            entity.HasOne(d => d.Pupil)
                .WithMany(p => p.TeacherPupils)
                .HasForeignKey(d => d.PupilID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherPupil_Pupil");

            entity.HasOne(d => d.Teacher)
                .WithMany(t => t.TeacherPupils)
                .HasForeignKey(d => d.TeacherID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeacherPupil_Teacher");
        });
    }
}
