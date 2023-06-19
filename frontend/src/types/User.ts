// export default interface User {
//   idPerson: string;
//   name: string;
//   surname: string;
//   email: string;
//   password: string;
//   remember: boolean;
// }

type User =
  | {
      idPerson: string;
      name: string;
      surname: string;
      email: string;
      password: string;
      remember: boolean;
    }
  | undefined;

export default User;
