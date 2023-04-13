import tkinter as tk

class FullNameGUI:
    def __init__(self):
        # create the main window
        self.window = tk.Tk()
        self.window.title("My Full Name")
        self.window.geometry("800x400")
        self.window.configure(bg="#FFFFFF")
        self.window.resizable(width=False, height=False)

        self.title_label = tk.Label(self.window, text="My Full Name", font=("Verdana", 16), fg="red", bg="white")
        self.title_label.place(x=110, y=7)

        self.given_name_label = tk.Label(self.window, text="Enter Given Name:", fg="red", font=("Verdana", 12))
        self.given_name_label.place(x=20, y=40)
        self.given_name_entry = tk.Entry(self.window, width=30)
        self.given_name_entry.place(x=200, y=40)

        self.middle_name_label = tk.Label(self.window, text="Enter Middle Name:", fg="red", font=("Verdana", 12))
        self.middle_name_label.place(x=20, y=80)
        self.middle_name_entry = tk.Entry(self.window, width=30)
        self.middle_name_entry.place(x=200, y=80)

        self.last_name_label = tk.Label(self.window, text="Enter Last Name:", fg="red", font=("Verdana", 12))
        self.last_name_label.place(x=20, y=120)
        self.last_name_entry = tk.Entry(self.window, width=30)
        self.last_name_entry.place(x=200, y=120)

        # create the output widgets
        self.full_name_label = tk.Label(self.window, text="Enter My Full Name is:", fg="red", font=("Verdana", 12))
        self.full_name_label.place(x=20, y=160)
        self.full_name_entry = tk.Entry(self.window, width=30)
        self.full_name_entry.place(x=200, y=160)

        # create the button widgets
        self.show_full_name_button = tk.Button(self.window, text="Show Full Name", command=self.show_full_name, width=20)
        self.show_full_name_button.place(x=220, y=190)
        self.clear_all_button = tk.Button(self.window, text="Clear All", command=self.clear_all, width=20)
        self.clear_all_button.place(x=220, y=220)

        # start the GUI
        self.window.mainloop()

    def show_full_name(self):
        given_name = self.given_name_entry.get()
        middle_name = self.middle_name_entry.get()
        last_name = self.last_name_entry.get()
        full_name = f"{last_name}, {given_name} {middle_name}"
        self.full_name_entry.delete(0, tk.END)
        self.full_name_entry.insert(0, full_name)

    def clear_all(self):
        self.given_name_entry.delete(0, tk.END)
        self.middle_name_entry.delete(0, tk.END)
        self.last_name_entry.delete(0, tk.END)
        self.full_name_entry.delete(0, tk.END)

if __name__ == '__main__':
    gui = FullNameGUI()