<template>
	<Toast />
	<Dialog header="Confirmation" v-model:visible="displayConfirmation" :style="{width: '350px'}" :modal="true">
		<div class="confirmation-content">
			<i class="pi pi-exclamation-triangle p-mr-3" style="font-size: 2rem" />
			<span>Are you sure you want to proceed?</span>
		</div>
		<template #footer>
			<Button label="No" icon="pi pi-times" @click="cancelBook" class="p-button-text"/>
			<Button label="Yes" icon="pi pi-check" @click="deleteBook" class="p-button-text" autofocus />
		</template>
	</Dialog>
  <div class="content">
    <div class="card-content">
      <Card>
        <template #title>
          <h1>Books</h1>
        </template>
        <template #content> 
          <div class="content-filter">
            <span class="p-field">
              <h5>Id</h5>
              <InputText id="id" type="text" v-model="id" disabled />
            </span>
            <span class="p-field">
              <h5>Title</h5>
              <InputText id="title" type="text" v-model="title" />
            </span>
            <span class="p-field">
              <h5>Price</h5>
              <InputNumber id="price" v-model="price" />
            </span>
            <span class="p-field">
              <h5>Authors</h5>
              <!--<Dropdown 
                v-model="selectedAuthor" 
                :options="optionsAuthors" 
                optionLabel="name"  
                placeholder="Select a Author" 
              />-->
              <Dropdown 
								v-model="selectedAuthor" 
								:options="optionsAuthors" 
								optionLabel="name" 
								:filter="true" 
								placeholder="Select a Author" 
								:showClear="true"
							>
								<template #value="slotProps">
									<div class="country-item country-item-value" v-if="slotProps.value">
										<div>{{slotProps.value.name}}</div>
									</div>
									<span v-else>
										{{slotProps.placeholder}}
									</span>
								</template>
								<template #option="slotProps">
									<div class="country-item">
										<div>{{slotProps.option.name}}</div>
									</div>
								</template>
            </Dropdown>
            </span>
          </div> 
          <div class="d-button">
            <Button label="Save" @click="save" v-if="isSave"/>
            <Button label="Update" @click="update" v-else/>
          </div>    
        </template>
      </Card>
    </div>
    
    <div class="d-datatable">
      <DataTable 
        :value="books" 
        :scrollable="true" 
        scrollHeight="400px" 
        responsiveLayout="scroll"
        filterDisplay="menu"
        v-model:filters="filters"
      >
        <Column field="id" header="ID" :sortable="true"></Column>
        <Column 
          field="title" 
          filterField="title"
          :sortable="true" 
          :showFilterMatchModes="false"
          header="Title"
        >
          <template #filter="{filterModel}">
              <div class="mb-3 font-bold">Title</div>
              <InputText v-model="filterModel.value"/>
          </template>
        </Column>
        <Column 
          field="price" 
          header="Price"
          filterField="price" 
          :showFilterMatchModes="false"  
        >
          <template #filter="{filterModel}">
              <div class="mb-3 font-bold">Price</div>
              <InputText v-model="filterModel.value"/>
          </template>
        </Column>
        <Column field="author.name" header="Author"></Column>
        <Column :exportable="false">
          <template #body="slotProps">
            <Button icon="pi pi-pencil" class="p-button-rounded p-button-success p-mr-2" @click="editBook(slotProps.data)" />
            <Button icon="pi pi-trash" class="p-button-rounded p-button-warning" @click="confirmDeleteBook(slotProps.data.id)" />
          </template>
        </Column>
        <template #empty>
            No records found.
        </template>
      </DataTable>
    </div>
  </div>
</template>

<script>
import { FilterMatchMode } from 'primevue/api';
import BookService from '../services/BookService';
import AuthorService from '../services/AuthorService';

export default {
  name: 'Book',
  data() {
    return {
      book: null,
      id: null,
      title: '',
      price: null,
      books: [],
      optionsAuthors: [],
      selectedAuthor:null,
      isSave: true,
      displayConfirmation: false,
      filters: []
    }
  },
  bookService: null,
  authorService: null,
  created() {
    this.bookService = new BookService();
    this.authorService = new AuthorService();
    this.filters = this.initFilters();
  },
  async mounted() {
    await this.requestGetAuthors();
    await this.requestGetBooks();
  },
  methods: {
    initFilters() {
      return {
        'title': { value: null, matchMode: FilterMatchMode.CONTAINS },
        'price': { value: null, matchMode: FilterMatchMode.CONTAINS },
      };
    },
    showSuccess() {
        this.$toast.add({severity:'success', summary: 'Success Message', detail:'Message Content', life: 3000});
    },
    showError() {
        this.$toast.add({severity:'error', summary: 'Error Message', detail:'Message Content', life: 3000});
    },
    async save() {
      let book = {
        'title': this.title,
        'price': this.price
      };
      if(this.selectedAuthor) {
        book.author = {
          'id': this.selectedAuthor.id
        };
      }
      await this.requestPostBook(book);
      this.clearField();
    },
    async update() {
      let book = {
        'title': this.title,
        'price': this.price
      };
      if(this.selectedAuthor) {
        book.author = {
          'id': this.selectedAuthor.id
        };
      }
      await this.requestPutBook(this.id, book);
      this.clearField();
      this.isSave = true;
    },
    async deleteBook(){
      await this.requestDeleteBook(this.id);
      this.displayConfirmation = false;
      this.clearField();
      this.isSave = true;
    },
    cancelBook() {
      this.id= null;
      this.displayConfirmation = false;
      this.clearField();
      this.isSave = true;
    },
    clearField() {
      this.id = null,
      this.title = '',
      this.price = null,
      this.selectedAuthor = null
    },
    editBook(data) {
      this.title = data.title;
      this.price = data.price;
      this.id = data.id;
      let author = {...data.author};
      if(author.name !== '-') {
        this.selectedAuthor = {
            id: author.id,
            name: author.name    
        };
      } else {
          this.selectedAuthor = null;
      }
      this.isSave = false;
    },
    confirmDeleteBook(value) {
      this.id = value;
      this.displayConfirmation = true;
    },
    async requestGetBooks() {
      await this.bookService.getBooks()
        .then(response => {
          let data = response.data;
          this.books = [];
          data.forEach(book => {
            let bookLocal = {...book};
            bookLocal.author =  bookLocal.author ? bookLocal.author : { name: '-'};
            this.books.push({...bookLocal});
          });
        })
        .catch(() => {
          console.log('Ocorreu um erro!');
        });
    },
    async requestGetAuthors() {
      await this.authorService.getAuthors()
        .then(response => {
          let data = response.data;
          this.optionsAuthors = [];
          data.forEach(author => {
            this.optionsAuthors.push({
              id: author.id,
              name: author.name
            })
          });
        })
        .catch(() => {
          this.optionsAuthors=[];
          this.showError();
        })
    },
    async requestPostBook(book = {}) {
      await this.bookService.postBooks(book)
        .then(() => {
          this.requestGetBooks();
          this.showSuccess();
        })
        .catch(error => {
          this.$toast.add({severity:'error', summary: 'Error Register', detail:`${error.response.data.title}`, life: 3000});
        })
    },
    async requestPutBook(bookId, book = {}) {
      await this.bookService.putBooks(bookId, book)
        .then(() => {
          this.requestGetBooks();
          this.showSuccess();
        })
        .catch(() => {
          this.showError();
        })
    },
    async requestDeleteBook(bookId) {
      await this.bookService.deleteBooks(bookId)
        .then(() => {
          this.requestGetBooks();
          this.showSuccess();
        })
        .catch(() => {
          this.showError();
        })
    }
  }
}

</script>