using System.ComponentModel.DataAnnotations;

namespace GameLibrary.Data
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public string? CreatedBy { get; set; }
    }
}

// Authentikimi
/*
 * Eshte mnbajtja e te dhenave te sigurta dhe krijimi i nje entiteti qe percakton akesesueshmerine e entiteteve ne nje nivel te caktuar
 * Useri eshte ne vetvete nje entitet i cili na lejon t aksesojme ose jo ne nivele te ndryshme
 * 
 * 
 * AUTHENTIKIMI
 * Authentikimi i referohet nje procesiqe verifikon identitetin e nje useri.
 * Perfshin konfirmimin nqs useri mund ta aksesoje ose te performoje disa aksione.
 * Kjo quhet Identity Authentication
 * Identity Framework (Authentikimi) eshte i perdorur per te menaxhuar userat dhe autorizimin. Na jep mundesi te perdorim user registration,
 * Login, pass management, role based authorisation
 * Mund te punoje me (metoda) authentikimesh te ndryshme PSH:
 * COOKIES  TOKENS  EXTERNAL-PROVIDERS (si google ose facebook)
 * 
 * Ka 2 menyra per ta vendosur authentikimin
 * 1-) Te krijohet projekti me authentikim qe ne fillim
 * 2-) Te implementohet vete authentikimi me te gjithe metodat e veta nga fillimi
 * 
 * 1) 
 * Na shtohet nje database e re qe na shtohet per te menaxhuar usera role passworde etj.
 * Identity Platform na mundeson: 
 * User Management : Identity
 * Registration, Login, Password Management
 * Na mundeson verifikimin e emailit, pass recovery dhe account locking
 * 
 * 2) 
 * Authentication Methods
 * Username dhe pass, Social logging (te hysh me fb ose google ose social network tjt)
 * Multi factor Authentication (MFA) psh me email dhe nr teli njeheresh
 * Single sign on across multiple applications
 * SSO (Single sign on) te lejon te logohesh nje ehre te vetme ne shume applications qe perdorin te njejten database
 * 
 * 3) 
 * Authorisation 
 * Na ofron ne nje kontroll mbi aksesin e roleve ose (role-based access control {RBAC}) dhe mekanizma te tjera te authorisation 
 * te cilat na lejojne te kontrollojme aksesimin e web application nga useri ne baze te roleve dhe premissionsave te tyre
 * 
 * 
 * 4) 
 * Secutiry
 * Identity Platform na mundeson ne security features si psh: 
 * Encryption, Secure storage of user's credentials dhe mbrojtja nga sulme si: 
 * Cross site scripting;    Sql Injection; 
 * 
 * 
 */

// 