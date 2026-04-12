# Hastane Yönetim Sistemi (Hospital Management System)

.NET Framework tabanlı masaüstü uygulaması; hasta, doktor ve sekreter rolleriyle randevu takibi, branş ve doktor yönetimi ile duyuru paylaşımını destekler. Veriler Microsoft SQL Server üzerinde saklanır.

## Bu proje ne için?

C# öğrenirken **pratik amaçlı**, kapsamı bilinçli olarak **sınırlı tutulmuş** basit bir uygulamadır. Amaç; Windows Forms, temel veritabanı işlemleri ve çok rollü bir akışı deneyimlemektir. Üretim ortamı veya tam kapsamlı bir hastane bilgi sistemi hedeflenmemiştir.

## Teknolojiler

| Bileşen | Açıklama |
|--------|----------|
| **.NET Framework** | 4.7.2 |
| **Arayüz** | Windows Forms |
| **Veritabanı** | SQL Server (`System.Data.SqlClient`) |
| **Geliştirme** | Visual Studio 2022 uyumlu çözüm |

## Özellikler

### Hasta

- Kayıt (ad, soyad, T.C., telefon, şifre, cinsiyet)
- T.C. ve şifre ile giriş
- Profil bilgilerini güncelleme
- Branş ve doktora göre randevu oluşturma (şikayet alanı ile)
- Bekleyen ve tamamlanan randevuları görüntüleme

### Doktor

- T.C. ve şifre ile giriş
- Randevu listesini görüntüleme ve detay inceleme
- Profil bilgilerini güncelleme
- Duyuruları görüntüleme

### Sekreter

- T.C. ve şifre ile giriş
- Randevu oluşturma
- Branş (`tbl_field`) ve doktor (`tbl_doctor`) yönetimi için panellere erişim
- Tüm randevuların listelenmesi (`FormAppointmentList`)
- Duyuru ekleme ve duyuruları görüntüleme

## Proje yapısı

```
Hospital Management System.sln
Hospital Management System/
├── Program.cs                 # Giriş: FormRoleScreen
├── DatabaseConnection.cs      # SQL Server bağlantısı
├── FormRoleScreen.cs          # Rol seçimi (Hasta / Doktor / Sekreter)
├── FormPatient*.cs            # Hasta kayıt, giriş, detay, bilgi güncelleme
├── FormDoctor*.cs             # Doktor giriş, panel, detay, bilgi güncelleme
├── FormSecretary*.cs          # Sekreter giriş ve işlem ekranı
├── FormField.cs               # Branş yönetimi
├── FormAppointmentList.cs     # Randevu listesi
├── FormAnnouncements.cs       # Duyurular
└── App.config
```

## Gereksinimler

- Windows ve **Visual Studio** (Windows Forms iş yükü ile) veya MSBuild
- **SQL Server** (ör. Express); yerel örnek: `SQLEXPRESS`
- Veritabanı adı uygulamada **`HospitalManagementSystem`** olarak kullanılıyor

## Veritabanı

Veri katmanı **bilinçli olarak sade tutulmuştur**. Tablolar arasında **foreign key veya ilişkisel kısıtlar** kullanılmamıştır; hasta–randevu veya branş–doktor gibi bağlar uygulama kodunda, metin alanları (ör. `patient_tc`, `field`, `doctor` adı) üzerinden yönetilir. Bu yaklaşım öğrenme aşamasında şema ve sorgu karmaşıklığını azaltır; gerçek bir sistemde normalizasyon ve referans bütünlüğü tercih edilir.

Bağlantı dizesi `DatabaseConnection.cs` içinde tanımlıdır:

```csharp
Data Source=kerem\SQLEXPRESS;Initial Catalog=HospitalManagementSystem;Integrated Security=True;
```

Kendi ortamınıza göre **sunucu adını** (`Data Source`) ve gerekirse **kimlik doğrulamasını** güncelleyin.

### Tablolar ve alanlar

| Tablo | Alanlar |
|-------|---------|
| **tbl_secretary** | `id`, `name_surname`, `tc`, `password` |
| **tbl_announcement** | `id`, `announcement` |
| **tbl_appointments** | `id`, `date`, `time`, `field`, `doctor`, `status`, `patient_tc`, `patient_complaint` |
| **tbl_patient** | `id`, `name`, `surname`, `tc`, `phone`, `password`, `gender` |
| **tbl_field** | `id`, `name` |
| **tbl_doctor** | `id`, `name`, `surname`, `field`, `tc`, `password` |

Hasta, doktor ve sekreter girişleri **T.C. kimlik numarası ve şifre** ile yapılır. Sütun türleri ve uzunlukları, projedeki `INSERT` / `SELECT` ifadeleriyle uyumlu olacak şekilde tanımlanmalıdır.

## Derleme ve çalıştırma

1. SQL Server’da `HospitalManagementSystem` veritabanını oluşturun ve tabloları tanımlayın (veya mevcut bir yedeği geri yükleyin).
2. `DatabaseConnection.cs` içindeki bağlantı dizesini kendi sunucunuza göre düzenleyin.
3. Visual Studio ile `Hospital Management System.sln` dosyasını açın.
4. Çözümü derleyin (**Build** → **Build Solution**) ve çalıştırın (**F5**).

Komut satırından (PowerShell, çözüm klasöründe):

```powershell
msbuild "Hospital Management System.sln" /p:Configuration=Release
```

Çıktı: `Hospital Management System\bin\Release\` (veya `Debug`) altında `Hospital Management System.exe`.

## Lisans

Bu depo için açık bir lisans dosyası belirtilmemiştir; kullanım koşulları proje sahibine aittir.
