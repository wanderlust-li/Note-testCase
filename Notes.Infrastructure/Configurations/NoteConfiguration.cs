using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain.Entities;

namespace Notes.Infrastructure.Configurations;

public class NoteConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.HasData(
            new Note
            {
                Id = 1,
                Title = "TestTitle",
                Content = "TestContent"
            },
            new Note
            {
                Id = 2,
                Title = "SecondTestTitle",
                Content = "SecondContent"
            }
        );
    }
}