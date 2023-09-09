using System;
using System.Collections.Generic;
using LSGames.Shop.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace LSGames.Shop.Repository.DBContexts;

public partial class LsgamesShopContext : DbContext
{
    public LsgamesShopContext(DbContextOptions<LsgamesShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Good> Goods { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PRIMARY");

            entity.ToTable("carts", tb => tb.HasComment("購物車"));

            entity.HasIndex(e => e.GoodId, "FK_goods_TO_carts");

            entity.Property(e => e.CartId)
                .HasComment("購物車 PK")
                .HasColumnType("bigint(11)")
                .HasColumnName("cart_id");
            entity.Property(e => e.CreatedAt)
                .HasComment("建立時間")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.GoodId)
                .HasComment("商品 PK")
                .HasColumnType("bigint(11)")
                .HasColumnName("good_id");
            entity.Property(e => e.Price)
                .HasPrecision(18, 2)
                .HasComment("商品單價")
                .HasColumnName("price");
            entity.Property(e => e.Quantity)
                .HasComment("商品數量")
                .HasColumnType("int(11)")
                .HasColumnName("quantity");
            entity.Property(e => e.UpdatedAt)
                .HasComment("最後更新時間")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId)
                .HasComment("帳號 PK")
                .HasColumnType("bigint(11)")
                .HasColumnName("user_id");

            entity.HasOne(d => d.Good).WithMany(p => p.Carts)
                .HasForeignKey(d => d.GoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_goods_TO_carts");
        });

        modelBuilder.Entity<Good>(entity =>
        {
            entity.HasKey(e => e.GoodId).HasName("PRIMARY");

            entity.ToTable("goods", tb => tb.HasComment("商品"));

            entity.Property(e => e.GoodId)
                .HasComment("商品 PK")
                .HasColumnType("bigint(11)")
                .HasColumnName("good_id");
            entity.Property(e => e.CreatedAt)
                .HasComment("建立時間")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedUserId)
                .HasComment("建立帳號 PK")
                .HasColumnType("bigint(11)")
                .HasColumnName("created_user_id");
            entity.Property(e => e.Description)
                .HasMaxLength(1024)
                .HasComment("商品描述")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasComment("商品名稱")
                .HasColumnName("name");
            entity.Property(e => e.PreviewImagee)
                .HasMaxLength(50)
                .HasDefaultValueSql("'default.jpg'")
                .HasComment("商品預覽圖")
                .HasColumnName("preview_imagee");
            entity.Property(e => e.Price)
                .HasPrecision(18, 2)
                .HasComment("商品單價")
                .HasColumnName("price");
            entity.Property(e => e.Quantity)
                .HasComment("在庫數量")
                .HasColumnType("int(11)")
                .HasColumnName("quantity");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasComment("商品狀態")
                .HasColumnType("tinyint(4)")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasComment("最後更新時間")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedUserId)
                .HasComment("最後更新帳號 PK")
                .HasColumnType("bigint(11)")
                .HasColumnName("updated_user_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
