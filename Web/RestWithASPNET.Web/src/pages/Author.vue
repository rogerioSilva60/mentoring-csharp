<template>
  <div class="author">
    <Toolbar class="p-mb-4">
      <template #start>
        <Button label="New" icon="pi pi-plus" class="p-button-success p-mr-2" @click="openNew" />
        <Button label="Delete" icon="pi pi-trash" class="p-button-danger" @click="confirmDeleteSelected" :disabled="!selectedProducts || !selectedProducts.length" />
      </template>

      <template #end>
        <FileUpload mode="basic" accept="image/*" :maxFileSize="1000000" label="Import" chooseLabel="Import" class="p-mr-2 p-d-inline-block" />
        <Button label="Export" icon="pi pi-upload" class="p-button-help" @click="exportCSV($event)"  />
      </template>
    </Toolbar>
  </div>
</template>

<script>
export default {
  name: 'Author'
}
</script>